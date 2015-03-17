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
        // NOTE: The structures are concrete.  The 'doers' are interfaces.
        protected Parameters _p;
        protected Dictionary _d;
        protected DictionaryFile _df;
        protected IDictionaryReader _dr;
        protected ISearchPreparer _sp;
        protected SearchStructure _ss;
        protected IResultGenerator _rg;
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

            // Validate parameters.
            if (String.IsNullOrEmpty(_p.DictionaryFileName)) { throw new ArgumentException("Dictionary File Name was not specified."); }
            if (String.IsNullOrEmpty(_p.StartWord)) { throw new ArgumentException("Start Word was not specified."); }
            if (String.IsNullOrEmpty(_p.EndWord)) { throw new ArgumentException("End Word was not specified."); }
            if (String.IsNullOrEmpty(_p.ResultsFileName)) { throw new ArgumentException("Results File Name was not specified."); }
        }

        public override void LoadDictionary() 
        {
            _df = new DictionaryFile();
            _df.Name = _p.DictionaryFileName;
            _df.WordLengthFilter = _p.StartWord.Length;

            _dr = new DictionaryReader();
            _d = _dr.Read(_df);
        }
        
        public override void PrepareForSearch() 
        {
            _sp = (ISearchPreparer)new SearchPreparer(_p, _d);
            _ss = _sp.Prepare();
        }
        
        public override void ExecuteSearch() 
        {
            _rg = (IResultGenerator)new ResultGenerator(_ss);
            _rp = _rg.Generate();
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
    /// Experimenting with Template Pattern here so that each step can be replaced with an alternative implementation in a derived class.
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
            try
            {
                PromptForParameters();
                LoadDictionary();
                PrepareForSearch();
                ExecuteSearch();
                PrepareResults();
                WriteResults();
            }
            catch (Exception e)
            {
                // NOTE: Would normally inject an error logger into this controller.
                Console.Error.WriteLine(e.Message);
            }
        }
    }
}
