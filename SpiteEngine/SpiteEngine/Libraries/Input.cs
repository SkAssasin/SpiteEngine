using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiteEngine.Libraries
{
    public class Input
    {
        public static InputAxis[] inputAxis = [new InputAxis("Horizontal", [Keys.D, Keys.Right], [Keys.A, Keys.Left]),
                                    new InputAxis("Vertical", [Keys.W, Keys.Up], [Keys.S, Keys.Down])];
        public static InputButton[] inputButtons = [new InputButton("Shoot", [Keys.Space]), 
                                                    new InputButton("Left", [Keys.Left]), 
                                                    new InputButton("Right", [Keys.Right])];

        public static int GetAxis(string name)
        {
            InputAxis? i = Array.Find(inputAxis, inp => inp.name == name);
            return i != null ? i.value : 0;
        }
        public static bool GetButtonDown(string name)
        {
            InputButton? b = Array.Find(inputButtons, inp => inp.name == name);
            return b != null && b.value == 1;
        }
        public static bool GetButton(string name)
        {
            InputButton? b = Array.Find(inputButtons, inp => inp.name == name);
            return b != null && (b.value == 2 || b.value == 1);
        }
        public static bool GetButtonUp(string name)
        {
            InputButton? b = Array.Find(inputButtons, inp => inp.name == name);
            return b != null && b.value == 3;
        }
    }
    public class InputAxis(string _name, Keys[] _positiveKeys, Keys[] _negativeKeys)
    {
        public string name = _name;
        public Keys[] positiveKey = _positiveKeys;
        public Keys[] negativeKey = _negativeKeys;
        public int value = 0;
    }
    public class InputButton(string _name, Keys[] _keys)
    {
        public string name = _name;
        public Keys[] key = _keys;
        public int value = 0;
    }
}
