namespace CustomStack;
public class StackOfStrings : Stack<string>
{
    public bool IsEmpty() => Count == 0;

    public Stack<string> AddRange(Stack<string> stack)
    {
        stack.ToList().ForEach(Push);
        return this;
    } 
}