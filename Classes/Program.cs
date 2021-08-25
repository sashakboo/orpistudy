using System;
using System.Collections.Generic;
using System.Linq;

namespace Classes
{
  class Program
  {
    static void Main(string[] args)
    {
      var entity = new Entity();
      var memo = new Memo();
      var extendedMemo = new ExtendedMemo();
      var work = new Work();
      var noEntity = new NoEntity();

      Console.WriteLine(work.GetType().IsAssignableFrom(memo.GetType()));

      var objs = new List<(object, object)>()
      {
        (entity, entity),
        (entity, memo),
        (memo, entity),
        (entity, noEntity),
        (memo, extendedMemo),
        (extendedMemo, memo),
        (extendedMemo, entity),
        (work, memo),
        (work, entity)
      };

      foreach (var (item1, item2) in objs)
      {
        Console.Write($"{item1.GetType().FullName} and {item2.GetType().FullName}:\r\n\t");

        try
        {
          string relation = ClassRelations(item1, item2);
          Console.WriteLine(relation);
          string commonAncestor = GetCommonAncestors(item1, item2);
          Console.WriteLine($"\tОбщие предки: {commonAncestor}");
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
      }

      Console.ReadKey();
    }

    static string ClassRelations(object obj1, object obj2)
    {
      if (obj1 == null)
        throw new ArgumentNullException(nameof(obj1));

      if (obj2 == null)
        throw new ArgumentNullException(nameof(obj2));

      var type1 = obj1.GetType();
      var type2 = obj2.GetType();

      if (type1.IsValueType)
        throw new ArgumentException(nameof(obj1), $"{nameof(obj1)} не является экземпляром класса");

      if (type2.IsValueType)
        throw new ArgumentException(nameof(obj2), $"{nameof(obj2)} не является экземпляром класса");

      if (type1 == type2)
        return $"Оба переданных объекта являются экземплярами класса {type1.FullName}";

      if (type1.IsSubclassOf(type2))
        return $"Класс {type2.FullName} является предком класса {type1.FullName}";

      if (type2.IsSubclassOf(type1))
        return $"Класс {type1.FullName} является предком класса {type2.FullName}";

      throw new ArgumentException($"Не удалось определить степень родства между классами {obj1.GetType().FullName} and {obj1.GetType().FullName}");
    }

    static string GetCommonAncestors(object obj1, object obj2)
    {
      var ancestorsType1 = GetAncestors(obj1.GetType());
      var ancestorsType2 = GetAncestors(obj2.GetType());

      var commonAncestor = ancestorsType1
        .Intersect(ancestorsType2)
        .Where(x => x != typeof(object))
        .ToList();

      if (commonAncestor.Any())
      {
        return string.Join(",", commonAncestor.Select(x => x.FullName));
      }

      return string.Empty;
    }

    static IEnumerable<Type> GetAncestors(Type type)
    {
      var baseType = type.BaseType;
      while (baseType != null)
      {
        yield return baseType;
        baseType = baseType.BaseType;
      }
    }

  }

  class Entity
  {

  }

  class Memo : Entity
  {

  }

  class ExtendedMemo : Memo
  {

  }

  class Work : Entity
  {

  }

  class NoEntity
  {

  }


}
