using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ElyseParser;
using ElyseLibrary;
using System.Runtime.Serialization.Formatters.Binary;
using ElyseRender;
using ElyseVisitors;


namespace ElyseEngine
{
    public class Engine
    {
        public SceneBuilder SceneBuilder;
        private ParserEngine parserEngine;
        private string elysePath;
        private List<Instruction> partialInstructions;
        private List<Instruction> finalInstructions;
        private VisitorEngine visitorEngine;
        private RenderEngine renderEngine;

        public Engine()
        {
            elysePath = System.IO.Path.GetFullPath(@"..\..\..\..\"); 
            SceneBuilder = new SceneBuilder();
            parserEngine = new ParserEngine(elysePath);
            partialInstructions = new List<Instruction>();
            finalInstructions = new List<Instruction>();
            visitorEngine = new VisitorEngine();
            renderEngine = new RenderEngine();
        }

        // Lancer l'animation
        public void Play()
        {
            partialInstructions = parserEngine.Run(SceneBuilder);
            //finalInstructions = visitorEngine.Run(partialInstructions);
            renderEngine.Run(partialInstructions);
        }

        // Sauvegarder le SceneBuilder
        public void Save(string savePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;
            stream = new FileStream(savePath, FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, SceneBuilder);
            stream.Flush();
            if (stream != null) stream.Close();
        }

        // Charger le SceneBuilder
        public void Load(string loadPath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;
            stream = new FileStream(loadPath, FileMode.Open, FileAccess.Read);
            SceneBuilder = (SceneBuilder)formatter.Deserialize(stream);
            if (stream != null) stream.Close();
        }
    }
}
