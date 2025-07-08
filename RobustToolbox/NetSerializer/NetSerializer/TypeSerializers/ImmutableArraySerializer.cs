using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace NetSerializer;

internal sealed class ImmutableArraySerializer : IStaticTypeSerializer
{
	public bool Handles(Type type)
	{
		return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(ImmutableArray<>);
	}

	public IEnumerable<Type> GetSubtypes(Type type)
	{
		return [type.GetGenericArguments()[0].MakeArrayType()];
	}

	public MethodInfo GetStaticWriter(Type type)
	{
		var elementType = type.GetGenericArguments()[0];

		return typeof(ImmutableArraySerializer)
			.GetMethod("Serialize", BindingFlags.Static | BindingFlags.NonPublic)!
			.MakeGenericMethod(elementType);
	}

	public MethodInfo GetStaticReader(Type type)
	{
		var elementType = type.GetGenericArguments()[0];

		return typeof(ImmutableArraySerializer)
			.GetMethod("Deserialize", BindingFlags.Static | BindingFlags.NonPublic)!
			.MakeGenericMethod(elementType);
	}

	// ReSharper disable once UnusedMember.Local
	private static void Serialize<T>(Serializer serializer, Stream stream, ImmutableArray<T> ob)
	{
		var array = ImmutableCollectionsMarshal.AsArray(ob);

		serializer.Serialize(stream, array);
	}

	// ReSharper disable once UnusedMember.Local
	private static void Deserialize<T>(Serializer serializer, Stream stream, out ImmutableArray<T> ob)
	{
		var array = (T[]) serializer.Deserialize(stream);

		ob = ImmutableCollectionsMarshal.AsImmutableArray(array);
	}
}
