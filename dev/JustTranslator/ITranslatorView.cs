using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JustTranslator
{
    public interface IWindowView
    {
        void Show();
        void Hide();
    }

    public interface ITranslatorView: IWindowView
    {
        event EventHandler Translate;
        string TextToTranslate { get; set; }
        string TextTranslated {get;set;}
    }
}
