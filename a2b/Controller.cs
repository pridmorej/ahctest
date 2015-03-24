using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace a2b
{
    /// <summary>
    /// This concrete controller implements each of the operations.
    /// </summary>
    public class Controller : AbstractController
    {
        // NOTE: The structures are concrete.  The 'doers' are interfaces.
        protected Dictionary _d;
        protected DictionaryFile _df;
        protected SearchStructure _ss;
        protected ResultPath _rp;
        protected ResultFile _rf;

        public Controller()
            : base()
        {
        }

        public override void LoadDictionary() 
        {
            _df = new DictionaryFile();
            _df.Name = _p.DictionaryFileName;
            _df.WordLengthFilter = _p.StartWord.Length;

            IDictionaryReader _dr = new DictionaryReader();
            _d = _dr.Read(_df);
        }
        
        public override void PrepareForSearch() 
        {
            ISearchPreparer _sp = new SearchPreparer(_p, _d);
            _ss = _sp.Prepare();
        }
        
        public override void GenerateResult() 
        {
            IResultGenerator _rg = new ResultGenerator(_ss);
            _rp = _rg.Generate();
        }
        
        public override void PrepareResults()
        {
            _rf = new ResultFile();
            _rf.Name = _p.ResultsFileName;
        }

        public override void WriteResults()
        {
            IResultWriter _rw = new ResultWriter(_rf, _rp);
            _rw.Write();
        }
    }
    
    /// <summary>
    /// Abstract Controller defines the order of the operations.
    /// </summary>
    /// <remarks>
    /// Experimenting with Template Pattern here so that each step can be replaced with an alternative implementation in a derived class.
    /// </remarks>
    public abstract class AbstractController : IController
    {
        protected Parameters _p;

        public AbstractController()
        {
        }

        public abstract void LoadDictionary();
        public abstract void PrepareForSearch();
        public abstract void GenerateResult();
        public abstract void PrepareResults();
        public abstract void WriteResults();

        public void Execute(string DictionaryFileName, string StartWord, string EndWord, string ResultsFileName)
        {
            try
            {
                // Validate parameters.
                if (String.IsNullOrEmpty(DictionaryFileName)) { throw new ArgumentException("Dictionary File Name was not specified."); }
                if (String.IsNullOrEmpty(StartWord)) { throw new ArgumentException("Start Word was not specified."); }
                if (String.IsNullOrEmpty(EndWord)) { throw new ArgumentException("End Word was not specified."); }
                if (String.IsNullOrEmpty(ResultsFileName)) { throw new ArgumentException("Results File Name was not specified."); }

                _p = new Parameters();
                _p.DictionaryFileName = DictionaryFileName;
                _p.StartWord = StartWord;
                _p.EndWord = EndWord;
                _p.ResultsFileName = ResultsFileName;

                LoadDictionary();
                PrepareForSearch();
                GenerateResult();
                PrepareResults();
                WriteResults();
            }
            catch (Exception e)
            {
                // NOTE: Would normally inject an error logger into this controller.
                Console.Error.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
