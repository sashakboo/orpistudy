using System;
using System.Collections.Generic;

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

      var objs = new List<(object, object)>()
      {
        (entity, entity),
        (entity, memo),
        (memo, entity),
        (entity, noEntity),
        (memo, extendedMemo),
        (extendedMemo, memo),
        (work, memo),
        (work, entity)
      };

      foreach (var (item1, item2) in objs)
      {
        try
        {
          string relation = ClassRelations(item1, item2);
          Console.WriteLine(relation);
        }
        catch (Exception ex)
        {
          Console.WriteLine(ex);
        }
      }

      Console.ReadKey();
    }

    static string ClassRelations<T1, T2>(T1 obj1, T2 obj2)
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

      if (type1.Equals(type2))
        return $"Оба переданных объекта являются экземплярами класса {type1.FullName}";

      if (type1.BaseType.Equals(type2))
        return $"Класс {type2.FullName} является предком класса {type1.FullName}";

      if (type2.BaseType.Equals(type1))
        return $"Класс {type1.FullName} является предком класса {type2.FullName}";

      throw new ArgumentException("Не удалось определить степень родства между классами");
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
