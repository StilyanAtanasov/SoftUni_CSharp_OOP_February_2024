using System.Reflection;

namespace AuthorProblem;

[Author("Stilyan")]
public class Tracker
{
    public void PrintMethodsByAuthor()
    {
        Type[] types = Assembly.GetExecutingAssembly().GetTypes();
        foreach (Type type in types)
        {
            if (type.GetCustomAttributes<AuthorAttribute>().Count() != 0)
            {
                foreach (Attribute attribute in type.GetCustomAttributes())
                {
                    AuthorAttribute attributes = (AuthorAttribute)attribute;
                    Console.WriteLine($"{type.Name} is written by {attributes.Name}");
                }

                foreach (MethodInfo methodInfo in type.GetMethods().Where(m => m.GetCustomAttributes<AuthorAttribute>().Count() != 0))
                    foreach (Attribute attribute in methodInfo.GetCustomAttributes())
                    {
                        AuthorAttribute attributes = (AuthorAttribute)attribute;
                        Console.WriteLine($"{methodInfo.Name} is written by {attributes.Name}");
                    }
            }
        }
    }
}