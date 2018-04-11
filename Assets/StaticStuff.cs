using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticStuff {

    public static int score = 0;

    public delegate void aDelegate();
    public static aDelegate OnScoreChange;
    public static aDelegate OnHealthChange;

}
