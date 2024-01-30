using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StoryEvent : MonoBehaviour
{
    // all story events have their "stat methods" ending with the proper stat index in the Variables file
    public abstract void Debugger();

    public abstract string NarrativeStart();


    public abstract string GetStatText(int i);
    public abstract string StrOption0();
    public abstract string WisOption1();
    public abstract string ChaOption2();
    public abstract string DexOption3();

    public abstract string GetStatPass(int i);
    public abstract string GetStatFail(int i);

    public abstract string StrPass0();
    public abstract string StrFail0();
    public abstract string WisPass1();
    public abstract string WisFail1();
    public abstract string ChaPass2();
    public abstract string ChaFail2();
    public abstract string DexPass3();
    public abstract string DexFail3();
}
