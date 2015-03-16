using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    public static class ControllerFactory
    {
        public static Controller GetInstance()
        {
            return new Controller();
        }
    }

    /// <summary>
    /// Experimenting with Template Pattern here.
    /// </summary>
    public class Controller : AbstractController
    {
        public override void PromptForParameters() { }
        public override void LoadDictionary() { }
        public override void PrepareForSearch() { }
        public override void ExecuteSearch() { }
        public override void PrepareResults() { }
        public override void WriteResults() { }
    }
    
    public abstract class AbstractController
    {
        public abstract void PromptForParameters();
        public abstract void LoadDictionary();
        public abstract void PrepareForSearch();
        public abstract void ExecuteSearch();
        public abstract void PrepareResults();
        public abstract void WriteResults();

        public void Execute()
        {
            PromptForParameters();
            LoadDictionary();
            PrepareForSearch();
            ExecuteSearch();
            PrepareResults();
            WriteResults();        
        }
    }
}
