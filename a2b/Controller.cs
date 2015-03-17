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
    /// This concrete controller implements each of the operations.
    /// </summary>
    public class Controller : AbstractController
    {
        protected Parameters _p;
        protected Dictionary _d;
        protected DictionaryFile _df;
        protected DictionaryReader _dr;
        protected ResultPath _rp;
        protected ResultFile _rf;
        protected IResultWriter _rw;

        public Controller()
            : base()
        {
        }

        public override void PromptForParameters()
        {
            IParameterGetter pg = ParameterGetterFactory.GetInstance();
            _p = pg.GetParameters();
        }

        public override void LoadDictionary() 
        {
            _df = new DictionaryFile();
            _df.Name = _p.DictionaryFileName;

            _dr = new DictionaryReader();
            _d = _dr.Read(_df);
        }
        
        public override void PrepareForSearch() 
        { 
        }
        
        public override void ExecuteSearch() 
        { 
        }
        
        public override void PrepareResults()
        {
            _rf = new ResultFile();
            _rf.Name = _p.ResultsFileName;
        }

        public override void WriteResults()
        {
            _rw = (IResultWriter)new ResultWriter(_rf, _rp);
            _rw.Write();
        }
    }
    
    /// <summary>
    /// Abstract Controller defines the order of the operations.
    /// </summary>
    /// <remarks>
    /// Experimenting with Template Pattern here.
    /// </remarks>
    public abstract class AbstractController
    {
        public AbstractController()
        {
        }

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
