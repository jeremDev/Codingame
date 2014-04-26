using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/* This is my inelegant partial solution for the Mars Landing easy and medium (not hard) difficulty exercises on codingame.com
 * http://www.codingame.com/cg/candidatedemoservlet?id=641408e17ca85e98d203ea5cd7453eb300bd and 
 * http://www.codingame.com/cg/candidatedemoservlet?id=6418477a6163c64f4b9e82e057574af7f625 */

class Player
{
    
    static void Main(String[] args) {
        
        bool isInitialized = false;
        String[] arrInputs = new String[6];
        inputs myInputs = new inputs();

        while (true) {
            
            if(!isInitialized) {
                int length;
                length = Convert.ToInt32(Console.ReadLine());
                for(int i=0; i < length; i++) {
                    myInputs.addGroundCoordinates(Console.ReadLine());
                }
                isInitialized = true;
            }
            else {
                arrInputs = Console.ReadLine().Split(' ');
                myInputs.X = Convert.ToInt32(arrInputs[0]);
                myInputs.Y = Convert.ToInt32(arrInputs[1]);
                myInputs.HS = Convert.ToInt32(arrInputs[2]);
                myInputs.VS = Convert.ToInt32(arrInputs[3]);
                myInputs.F = Convert.ToInt32(arrInputs[4]);
                myInputs.R = Convert.ToInt32(arrInputs[5]);
                myInputs.P = Convert.ToInt32(arrInputs[6]);
                
                Console.WriteLine(myInputs.calculateOutput());
                Console.Error.WriteLine("Coordinates: " + myInputs.Coordinates);
                Console.Error.WriteLine(String.Join(" ",arrInputs));
                //Console.Error.WriteLine(myInputs.rotation + " " + myInputs.power);
                
                Console.Error.WriteLine("TargetX1: " + myInputs.TargetX + " TargetX2: " + myInputs.TargetX2);
    
                //Console.WriteLine("-20 3");
            }
	    }
	}
}

class inputs
{
    private int x;
    private int y;
    private int hs;
    private int vs;
    private int f;
    private int r;
    private int p;
    private int targetx;
    private int targetx2;
    private int targety;
    private int trajectory; // negative numbers to positive numbers - to be multiplied by angle
    private int rotation;
    
    private List<int> groundCoordinates = new List<int>();
    
    public int X {
        get {
            return x;
        }
        set {
            x = value;
        }
    }
    
    public int Y {
        get {
            return y;
        }
        set {
            y = value;
        }
    }
    
    public int HS {
        get {
            return hs;
        }
        set {
            hs = value;
        }
    }
    
    public int VS {
        get {
            return vs;
        }
        set {
            vs = value;
        }
    }
    
    public int F {
        get {
            return f;
        }
        set {
            f = value;
        }
    }
    
    public int R {
        get {
            return r;
        }
        set {
            r = value;
        }
    }
    
    public int P {
        get {
            return p;
        }
        set {
            p = value;
        }
    }
    
    private string coordinates = "";
    
    public string Coordinates {
        get {
            //return "X: " + x + " Y: " + y + " HS: " + hs + " VS: " + vs + " F: " + " R: " + " P: " + p;
            return String.Join(" ", groundCoordinates);
        }
    }
    
    public void addGroundCoordinates(String vars) {
        String[] myVars = new String[2];
        myVars = vars.Split(' ');
        Console.Error.WriteLine(vars);
        groundCoordinates.Add(Convert.ToInt32(myVars[0]));
        groundCoordinates.Add(Convert.ToInt32(myVars[1]));
        int i = groundCoordinates.Count-1;
        if(groundCoordinates.Count > 2)
            if(groundCoordinates[i] == groundCoordinates[i-2]) {
                targetx = groundCoordinates[i-3];
                targetx2 = groundCoordinates[i-1];
            }
    }
    
    public int power {
        get {
            if(hs > 20)
                return 4;
            if(vs > -20)
                return 3;
            if(y < 2500)
                return 4;
            return 3;
        }
        
    }
    
    public int TargetX {
        set {
            targetx = value;
        }
        get {
            return targetx;
        }
    }
    
    public int TargetX2 {
        set {
            targetx2 = value;
        }
        get {
            return targetx2;
        }
    }
    
    public int TargetY {
        set {
            targety = value;
        }
        get {
            return targety;
        }
    }
    
    private int distanceToTarget() {
        if(x < targetx)
            return targetx - x;
        if(x > targetx2)
            return x - targetx2;
        return 0;
    }
    
    private int calculateRotation() {
        Math math = new Math();
        int magnitude = 1;
        if(y < 350)
            magnitude = 0;
        else if(math.abs(hs) > 30) {
            trajectory = math.sign(hs);
            magnitude = 45;
        }
        else if(x < math.abs(distanceToTarget()) + 100) {
            if(math.abs(hs) < 40 && math.abs(hs) > 10)
                magnitude = 0;
            else
                magnitude = 45;
            trajectory = -1;
        }
        else if(math.abs(distanceToTarget()) < 100 && math.abs(hs) > 20) {
            magnitude = 45;
            trajectory = math.sign(distanceToTarget()) * -1;
        }
        else if(x > math.abs(distanceToTarget()) + 20) {
            magnitude = 45;
            if(math.abs(hs) < 40 && math.abs(hs) > 10)
                magnitude = 0;
            else
                magnitude = 45;
        }
        else if(math.abs(hs) > 20) {
            magnitude = 30;
            trajectory = math.sign(hs);
        }
        rotation = magnitude * trajectory;
        return rotation;
    }
    
    public string calculateOutput() {
        
        return Convert.ToString(calculateRotation()) + " " + Convert.ToString(power);
    }
}

class Math {
    public int abs(int x) {
        if(x < 0)
            x = x * -1;
        return x;
    }
    
    public int sign(int x) {
        int ret = 1;
        if(x < 0)
            ret = -1;
        return ret;
    }
}
