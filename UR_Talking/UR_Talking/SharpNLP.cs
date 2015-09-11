using System.Collections.Generic;
using System.Linq;
using System.Web;
using java.io;
using Console = System.Console;

namespace UR_Talking
{
    public class SharpNLP
    {
       private string mModelPath = @"D:\Studium\Informationswissenschaften\UR-Talking\SharpNLP\Models\tokenize\";
        private OpenNLP.Tools.Tokenize.EnglishMaximumEntropyTokenizer mTokenizer;
        private OpenNLP.Tools.PosTagger.EnglishMaximumEntropyPosTagger mPosTagger;
        private OpenNLP.Tools.Parser.EnglishTreebankParser parser;

        public string[] TokenizeSentence(string sentence)
        {
            if(mTokenizer == null){
                mTokenizer = new OpenNLP.Tools.Tokenize.EnglishMaximumEntropyTokenizer(mModelPath + "de-token.nbin");
            }

            return mTokenizer.Tokenize(sentence);
        }

        public string[] PosTagTokens(string[] tokens)
        {
            if (mPosTagger == null)
            {
                mPosTagger = new OpenNLP.Tools.PosTagger.EnglishMaximumEntropyPosTagger(mModelPath + "de-pos-maxent.bin", mModelPath + "tagdict");
            }

            return mPosTagger.Tag(tokens);
        }


        public string[] ParseTokens(string[] tokens)
        {
            if (parser == null)
            {
                parser = new OpenNLP.Tools.Parser.EnglishTreebankParser(mModelPath + "tag.nbin", true, true);
            }

            return mPosTagger.Tag(tokens);
        }
    }
}