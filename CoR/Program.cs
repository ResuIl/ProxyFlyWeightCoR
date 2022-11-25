class Translate
{
    public string TextLanguage;
    public string TranslateTo;
    public string Text;

    public Translate(string textLanguage, string translateTo, string text)
    {
        TextLanguage = textLanguage;
        TranslateTo = translateTo;
        Text = text;
    }
}

abstract class BaseHandler
{
    protected BaseHandler _nextHandler;
    public void SetNextHandler(BaseHandler nextHandler)
    {
        _nextHandler = nextHandler;
    }

    public abstract void HandleRequest(Translate program);
}

class Translator1 : BaseHandler
{
    public override void HandleRequest(Translate program)
    {
        if (program.TextLanguage == "English" && program.TranslateTo == "Germany")
            Console.WriteLine($"{program.TranslateTo} Translated to {program.TextLanguage}");
        else
            _nextHandler.HandleRequest(program);
    }
}

class Translator2 : BaseHandler
{
    public override void HandleRequest(Translate program)
    {
        if (program.TextLanguage == "English" && program.TranslateTo == "China")
            Console.WriteLine($"{program.TranslateTo} Translated to {program.TextLanguage}");
        else
            _nextHandler.HandleRequest(program);
    }
}

class Translator3 : BaseHandler
{
    public override void HandleRequest(Translate program)
    {
        if (program.TextLanguage == "English" && program.TranslateTo == "Russia")
            Console.WriteLine($"{program.TranslateTo} Translated to {program.TextLanguage}");
        else
            _nextHandler.HandleRequest(program);
    }
}

class Error404 : BaseHandler
{
    public override void HandleRequest(Translate program)
    {
        Console.WriteLine("No Translator Found!");
    }
}

class Program
{
    static void Main()
    {
        Translate program = new Translate("English", "China", "Hello");

        Translator1 translator1 = new Translator1();
        Translator2 translator2 = new Translator2();
        Translator3 translator3 = new Translator3();
        Error404 error404 = new Error404();

        translator1.SetNextHandler(translator2);
        translator2.SetNextHandler(translator3);
        translator3.SetNextHandler(error404);

        translator1.HandleRequest(program);
    }
}