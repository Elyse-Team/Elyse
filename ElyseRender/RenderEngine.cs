using ElyseLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElyseRender
{
    public class RenderEngine : IInstructionVisitor<Instruction>
    {
        private Scene _scene;
        private List<Instruction> _storyInstructions;
        public string JsCode { get; set; }
        public RenderEngine()
        {

        }
        public void Run(List<Instruction> storyInstructions, Scene scene)
        {
            _scene = scene;
            _storyInstructions = storyInstructions;
            Init();
            foreach (Character c in scene.Characters)
            {
                /*
                 * PIXI
                JsCode += "var "+c.Name+" = story.addCharacter({name:'"+c.Name+"',";
                if(c.MyStyle == Character.Style.None) JsCode += "body='"+c.MyShirtColor+"',head:'smile',";
                else JsCode += "body='" + c.MyStyle + "',head:" + c.MyStyle + ",";
                */

            }


            JsCode += @"var paper = Raphael(100, 100, 1600, 900);";
            JsCode += @"new ElyseCore([";

            foreach (Instruction i in storyInstructions)
                visitInstruction(i);
            JsCode += @"[console,""log"",[""end""]]";
            JsCode += @"],function(){console.log(""animation done"");}).run();";

        }

        private void Init()
        {
            /*
             * PIXI
            JsCode = "var scene = {container : document.getElementById('scene'),debug : true},story = new Elyse(scene);";
            */

            //RAPHAEL

            
        }

        private void AddJsAction(string name, string function, params object[] p)
        {
            JsCode += @"[" + name + @",""" + function + @""",[";
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i] is int) JsCode += p[i];
                if (p[i] is string) JsCode += @"""" + p[i] + @"""";
                if (i < p.Length - 1) JsCode += ",";
            }
            JsCode += "]],\n";
        }

        internal void OpenBlock()
        {
            JsCode += "[";
        }
        internal void CloseBlock()
        {
            JsCode += "]";
        }

        public Instruction visitInstruction(Instruction i)
        {
            return i.Accept(this);
        }

        public Instruction visit(Move i)
        {
            int xtarget = i.Target.X;
            i.Target = _scene.FindFreePosition(i.Target);
            AddJsAction(i.Entity.Name, "lookAt", (i.Entity.X < i.Target.X) ? "right" : "left");
            AddJsAction(i.Entity.Name, "moveToAbs", (i.Target.X) * 300 + 50, 400 - ((i.Target.Y) * 400), 500 * (Math.Abs(i.Entity.X - i.Target.X)), "linear");
            AddJsAction(i.Entity.Name, "lookAt", (i.Target.X < xtarget) ? "right" : "left");
            i.Entity.X = i.Target.X;
            i.Entity.Y = i.Target.Y;
            return i;
        }

        public Instruction visit(Feel i)
        {
            throw new NotImplementedException();
        }

        public Instruction visit(Talk i)
        {
            throw new NotImplementedException();
        }

        public Instruction visit(Think i)
        {
            throw new NotImplementedException();
        }

        public Instruction visit(Fight i)
        {
            throw new NotImplementedException();
        }


        public Instruction visit(Error i)
        {
            throw new NotImplementedException();
        }




        public Instruction visit(BackgroundSet i)
        {
            throw new NotImplementedException();
        }

        public Instruction visit(Narrator i)
        {
            throw new NotImplementedException();
        }

        public Instruction visit(TimeSet i)
        {
            throw new NotImplementedException();
        }
    }
}
