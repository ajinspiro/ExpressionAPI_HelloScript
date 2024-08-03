using System.Linq.Expressions;
using System.Reflection;

AI.Default.Main();

namespace AI
{
    public class Default
    {
        /* Array demo */
        /* Numerical Array, While */
        public static void Main()
        {
            var rulesParam = Expression.Parameter(typeof(string[]), "rules");
            var iVar = Expression.Variable(typeof(int), "i");
            var stringList = Expression.Constant(new List<string>());
            var stringListAdd = typeof(List<string>).GetMethod("Add") ?? throw new Exception();
            var stringListClear = typeof(List<string>).GetMethod("Clear") ?? throw new Exception();
            var intToString = typeof(int).GetMethod("ToString", []) ?? throw new Exception(); ;
            var writeLine = typeof(Console).GetMethod("WriteLine", [typeof(string)]) ?? throw new Exception();
            var concat = typeof(string).GetMethod("Concat", [typeof(IEnumerable<string?>)]) ?? throw new Exception();
            var loopBreak = Expression.Label();
            
            var loopBody = Expression.Block(
                [iVar],
                Expression.Call(stringList, stringListClear),
                Expression.Call(stringList, stringListAdd, Expression.Constant("Rule ")),
                Expression.Call(stringList, stringListAdd, Expression.Call(Expression.Increment(iVar), intToString)),
                Expression.Call(stringList, stringListAdd, Expression.Constant(" : ")),
                Expression.Call(stringList, stringListAdd, Expression.ArrayIndex(rulesParam, iVar)),

                Expression.Call(writeLine,
                Expression.Call(concat, stringList)
                ),
                Expression.AddAssign(iVar, Expression.Constant(1)),
                Expression.IfThen(
                    Expression.GreaterThanOrEqual(iVar, Expression.PropertyOrField(rulesParam, "Length")),
                    Expression.Break(loopBreak)
                    )
                );
            var loop = Expression.Loop(loopBody, loopBreak);

            var lambda = Expression.Lambda<Action<string[]>>(loop, rulesParam).Compile();
            string[] rules = { "Do no harm", "Obey", "Continue Living" };
            lambda(rules);
        }
    }
}

namespace AH
{
    public class Default
    {
        /* copying range value to a variable */
        // skipping
    }
}

namespace AG
{
    public class Default
    {
        public static void Main()
        {
            /* Range based for loop */
            var numbers = Expression.Constant(Enumerable.Range(11, 3).ToArray());
            var writeline = typeof(Console).GetMethod("WriteLine", [typeof(int)]) ?? throw new Exception();

            var i = Expression.Variable(typeof(int), "i");
            var setITo0 = Expression.Assign(i, Expression.Constant(0));

            var loopBreak = Expression.Label();

            var loopBlock = Expression.Block(
                Expression.Call(writeline, Expression.ArrayIndex(numbers, i)),
                Expression.AddAssign(i, Expression.Constant(1)),
                Expression.IfThen(
                    Expression.GreaterThan(i, Expression.Constant(2)),
                    Expression.Break(loopBreak)
                    )
                );

            var loop = Expression.Loop(
                 loopBlock, loopBreak
                 );

            var body = Expression.Block(
                [i],
                setITo0,
                loop
                );

            Expression.Lambda<Action>(body).Compile()();
        }
    }
}

namespace AF
{
    public class Default
    {
        public static void Main()
        {
            /* Access a property using it name as string */
            var arun = new User() { Name = "arun" };

            string prop = "Name";

            var propInfo = typeof(User).GetProperty(prop) ?? throw new Exception();

            var value = propInfo.GetValue(arun);

            Console.WriteLine(value);
        }
    }
    public class User
    {
        public string Name { get; set; } = string.Empty;
    }

}

namespace AE
{
    public class Default
    {
        public static void Main()
        {
            /* Range based for loop */
            var numbers = Expression.Constant(Enumerable.Range(11, 3).ToArray());
            var writeline = typeof(Console).GetMethod("WriteLine", [typeof(int)]) ?? throw new Exception();

            var i = Expression.Variable(typeof(int), "i");
            var setITo0 = Expression.Assign(i, Expression.Constant(0));

            var loopBreak = Expression.Label();

            var loopBlock = Expression.Block(
                Expression.Call(writeline, Expression.ArrayIndex(numbers, i)),
                Expression.AddAssign(i, Expression.Constant(1)),
                Expression.IfThen(
                    Expression.GreaterThan(i, Expression.Constant(2)),
                    Expression.Break(loopBreak)
                    )
                );

            var loop = Expression.Loop(
                 loopBlock, loopBreak
                 );

            var body = Expression.Block(
                i,
                setITo0,
                loop
                );

            Expression.Lambda<Action<int>>(body, i).Compile()(123);
        }
    }
}

namespace AD
{
    public class Default
    {
        public static void Main()
        {
            /* If,else condition */
            var constYear = Expression.Constant(2020);
            var cond = Expression.Condition(
                Expression.GreaterThan(constYear, Expression.Constant(2009)),
                Expression.Constant("You are in india and you have already enrolled for engineering. Game Over!"),
                Expression.Condition(
                    Expression.LessThan(constYear, Expression.Constant(2008)),
                    Expression.Constant("Stay away from ready made custom advices please!"),
                    Expression.Constant("Anything wrong with your time machine? You have not gone anywhere, kiddo.")
                    )
                );
            var writeline = typeof(Console).GetMethod("WriteLine", [typeof(string)]) ?? throw new Exception();
            var writelineCall = Expression.Call(writeline, cond);
            Expression.Lambda<Action>(writelineCall).Compile()();
        }
    }
}

namespace AC
{
    public class Default
    {
        public static void Main()
        {
            /* Format a string using string interpolation */
            // skipping
        }
    }
}

namespace AB
{
    public class Default
    {
        public static void Main()
        {
            /*
             * Insert the value of an object, variable, or expression
             * into another string using string formatting.
             */
            var pArgs = new object[] { 101, "C#" };
            var pArgsExp = Expression.Constant(pArgs);
            var pStrExp = Expression.Constant("String formatting {0} with {1}");

            MethodInfo stringFormat = typeof(string)
                        .GetMethod("Format", [typeof(string), typeof(object?[])])
                        ?? throw new ArgumentNullException();

            var stringFormatCall = Expression.Call(stringFormat, [pStrExp, pArgsExp]);
            var writeline = typeof(Console)
                .GetMethod("WriteLine", [typeof(string)])
                ?? throw new ArgumentNullException();

            var writelineCall = Expression.Call(writeline, stringFormatCall);
            Expression.Lambda<Action>(writelineCall).Compile()();
        }
    }
}

namespace AA
{
    public class Default
    {
        public static void Main()
        {
            /* A Simple Console Output */
            MethodInfo? writeline = typeof(Console)
                                        .GetMethod("WriteLine", [typeof(string)]);
            if (writeline is null) throw new Exception();
            ConstantExpression hello = Expression.Constant("Hello!");
            MethodCallExpression writelineCall = Expression.Call(writeline, hello);
            Expression.Lambda<Action>(writelineCall).Compile()();
        }
    }
}
