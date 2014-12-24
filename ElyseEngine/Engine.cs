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


namespace ElyseEngine
{
    public class Engine
    {
        private SceneBuilder sceneBuilder;
        private ParserEngine parserEngine;
        private string elysePath;
        private List<Instruction> storyInstructions;
        private RenderEngine renderEngine;

        public Engine()
        {
            elysePath = "B:/Visual Studio Projects";
            sceneBuilder = new SceneBuilder();
            parserEngine = new ParserEngine(elysePath);
            storyInstructions = new List<Instruction>();
            renderEngine = new RenderEngine();
        }

        // Lancer l'animation
        public void Play()
        {
            storyInstructions = parserEngine.Run(sceneBuilder);
            renderEngine.Run(storyInstructions);
        }

        // Sauvegarder le SceneBuilder
        public void Save(string savePath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;
            stream = new FileStream(savePath, FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, sceneBuilder);
            stream.Flush();
            if (stream != null) stream.Close();
        }

        // Charger le SceneBuilder
        public void Load(string loadPath)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;
            stream = new FileStream(loadPath, FileMode.Open, FileAccess.Read);
            sceneBuilder = (SceneBuilder)formatter.Deserialize(stream);
            if (stream != null) stream.Close();
        }
    }
}
