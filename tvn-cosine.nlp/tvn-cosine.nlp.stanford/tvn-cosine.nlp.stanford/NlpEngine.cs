using System.Collections.Generic;
using System.Collections.Generic;
using edu.stanford.nlp.pipeline;
using edu.stanford.nlp.ling;
using edu.stanford.nlp.util;
using edu.stanford.nlp.trees;
using edu.stanford.nlp.neural.rnn;
using static edu.stanford.nlp.sentiment.SentimentCoreAnnotations;
using Tvn.Cosine.Text.Nlp;

namespace tvn_cosine.nlp.stanford
{
    public class NlpEngine
    {
        private readonly StanfordCoreNLP pipeline;
        private readonly string localModelPath;
        private readonly object syncLock = new object();

        public NlpEngine(string localModelPath = "c:/stanford/models/")
        {
            this.localModelPath = localModelPath;
            pipeline = new StanfordCoreNLP(InitProperties());
        }

        public string Version
        {
            get
            {
                return "stanford-corenlp-3.7.0";
            }
        }

        public Newsclip.Text.Nlp.Document Process(string text)
        {
            lock (syncLock)
            {
                var sentences = new List<Sentence>();
                var tokens = new List<Token>();

                var annotation = new Annotation(text);
                pipeline.annotate(annotation);

                var sentencesStanford = (java.util.List)annotation.get(typeof(CoreAnnotations.SentencesAnnotation));
                if (sentencesStanford != null && sentencesStanford.size() > 0)
                {
                    for (int i = 0; i < sentencesStanford.size(); ++i)
                    {
                        var sentence = (CoreMap)sentencesStanford.get(i);
                        var sentiment = (string)sentence.get(typeof(SentimentClass));
                        var tree = (Tree)sentence.get(typeof(SentimentAnnotatedTree));
                        var score = RNNCoreAnnotations.getPredictions(tree).getMatrix().getData();
                        var sentDic = new Dictionary<Sentiment, double>();
                        var tokensSentence = getTokens((java.util.List)sentence.get(typeof(CoreAnnotations.TokensAnnotation)));
                        var ner = getNamedEntities(tokensSentence);

                        for (int s = 0; s < score.Length; ++s)
                        {
                            var sent = getSentimentObject(s);
                            sentDic[sent] = score[s];
                        }

                        sentences.Add(new Sentence(sentence.ToString(), tokensSentence, ner, new Sentiment(sentiment), sentDic));
                        tokens.AddRange(tokensSentence);
                    }
                }
                return new Tvn.Cosine.Text.Nlp.Document(text, sentences, tokens);
            }
        }

        private java.util.Properties InitProperties()
        {
            var properties = new java.util.Properties();
            properties.setProperty("parse.model", localModelPath + "edu/stanford/nlp/models/srparser/englishSR.ser.gz");
            properties.setProperty("sentiment.model", localModelPath + "edu/stanford/nlp/models/sentiment/sentiment.ser.gz");
            properties.setProperty("pos.model", localModelPath + "edu/stanford/nlp/models/pos-tagger/english-left3words/english-left3words-distsim.tagger");
            properties.setProperty("ner.model", localModelPath + "edu/stanford/nlp/models/ner/english.all.3class.distsim.crf.ser.gz");
            properties.setProperty("dcoref.demonym", localModelPath + "edu/stanford/nlp/models/dcoref/demonyms.txt");
            properties.setProperty("dcoref.states", localModelPath + "edu/stanford/nlp/models/dcoref/state-abbreviations.txt");
            properties.setProperty("dcoref.animate", localModelPath + "edu/stanford/nlp/models/dcoref/animate.unigrams.txt");
            properties.setProperty("dcoref.inanimate", localModelPath + "edu/stanford/nlp/models/dcoref/inanimate.unigrams.txt");
            properties.setProperty("dcoref.big.gender.number", localModelPath + "edu/stanford/nlp/models/dcoref/gender.data.gz");
            properties.setProperty("dcoref.countries", localModelPath + "edu/stanford/nlp/models/dcoref/countries");
            properties.setProperty("dcoref.states.provinces", localModelPath + "edu/stanford/nlp/models/dcoref/statesandprovinces");
            properties.setProperty("dcoref.singleton.model", localModelPath + "edu/stanford/nlp/models/dcoref/singleton.predictor.ser");
            properties.setProperty("annotators", "tokenize, ssplit, pos, parse, lemma, ner, sentiment");
            properties.setProperty("tokenize.language", "en");
            properties.setProperty("ner.useSUTime", "0");
            properties.setProperty("sutime.binders", "0");
            properties.setProperty("sutime.rules", localModelPath + "edu/stanford/nlp/models/sutime/defs.sutime.txt, " + localModelPath + "edu/stanford/nlp/models/sutime/english.sutime.txt");

            return properties;
        }

        private List<Token> getNamedEntities(ICollection<Token> tokens)
        {
            NamedEntity prevNamedEntity = null;
            string tempToken = string.Empty;
            string prevPos = string.Empty;
            var returnValue = new List<Token>();

            foreach (var token in tokens)
            {
                if (prevNamedEntity == null || token.NamedEntity.Name != prevNamedEntity.Name)
                {
                    if (!string.IsNullOrWhiteSpace(tempToken))
                    {
                        returnValue.Add(new Token(tempToken.Trim(), null, prevNamedEntity));
                        tempToken = string.Empty;
                    }
                }
                prevPos = token.PartOfSpeechTag.Name;
                prevNamedEntity = token.NamedEntity;

                if (token.NamedEntity.Name != "O")
                {
                    tempToken += string.Format(" {0}", token.Value);
                }
            }

            if (!string.IsNullOrWhiteSpace(tempToken))
            {
                returnValue.Add(new Token(tempToken.Trim(), new PartOfSpeechTag(prevPos), prevNamedEntity));
            }

            return returnValue;
        }

        private List<Token> getTokens(java.util.List tokens)
        {
            var returnValue = new List<Token>();
            if (tokens != null && tokens.size() > 0)
            {
                for (int i = 0; i < tokens.size(); ++i)
                {
                    var token = (CoreMap)tokens.get(i);
                    var tokenText = (string)token.get(typeof(CoreAnnotations.OriginalTextAnnotation));
                    var pos = (string)token.get(typeof(CoreAnnotations.PartOfSpeechAnnotation));
                    var ner = (string)token.get(typeof(CoreAnnotations.NamedEntityTagAnnotation));
                    var lemma = token.get(typeof(CoreAnnotations.LemmaAnnotation));

                    returnValue.Add(new Token(tokenText, new PartOfSpeechTag(pos), new NamedEntity(ner, "")));
                }
            }
            return returnValue;
        }
    }
}
