using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaghetti : StoryEvent
{
    // all story events have their "stat methods" ending with the proper stat index in the Variables file

    public override void Debugger()
    {
        Debug.Log("Spaghetti");
    }

    public override string NarrativeStart()
    {
        return "While walking you discover a block of spaghetti in the road. Is is quite a lot of spaghetti. Several townsfolk stand all around scratching their heads at the untimely sight.";
    }

    public override string StrOption0()
    {
        return "Push your way through the spaghetti";
    }

    public override string WisOption1()
    {
        return "Scour your wisdom to determine if spaghetti has a weakness";
    }

    public override string ChaOption2()
    {
        return "Convince the townsfolk to help you move this spaghetti so you continue on";
    }

    public override string DexOption3()
    {
        return "Gracefully parkour over the spaghetti to the other side";
    }

    public override string StrPass0()
    {
        return "With great strength you push the spaghetti aside like Moses and the red sea. The townsfolk stare on in awe as you muscle your way through.";
    }

    public override string StrFail0()
    {
        return "Despite all your strength you fall to the wet noodles that is the spaghetti. Embarassed and covered with sauce, you shamefully take the longer route around.";
    }

    public override string WisPass1()
    {
        return "In a moment of absolute glory, you remember that spaghetti is edible! You begin to eat your way through, carving a tunnel through the spaghetti to the otherside.";
    }

    public override string WisFail1()
    {
        return "Sadly, when it comes to spaghetti, you determine no weakness in the roadblock. You hang your head and take another way, defeated by the pile of noodles.";
    }

    public override string ChaPass2()
    {
        return "With great vigor you convince the townsfolk to help you move the spaghetti for everyone's benefit. It doesn't take too long and the townsfolk are thrilled that roadblock is gone.";
    }

    public override string ChaFail2()
    {
        return "You try to rally the townsfolk but your words fall on deaf ears. The townsfolk are not interested in helping you or this spaghetti. You walk away taking the longer route around.";
    }

    public override string DexPass3()
    {
        return "With your sick skills you manage to jump from building to building, circumventing the spaghetti entirely. The townspeople gasp and whoo you as your jump to the otherside.";
    }

    public override string DexFail3()
    {
        return "Though you put much effort in, while trying to jump the spaghetti mound you can't manage to break the top and instead fall on some sauce. Embarassed, wet, and defeated, you shamefully walk around as " +
            "the townsfolk laugh at your failed efforts.";
    }

    public override string GetStatText(int i)
    {
        
        if(i == 0)
        {
            return StrOption0();

        }else if(i == 1)
        {

            return WisOption1();

        }else if(i == 2)
        {
            return ChaOption2();
        }
        else
        {
            return DexOption3();
        }
    }

    public override string GetStatPass(int i)
    {
        if (i == 0)
        {
            return StrPass0();
        }
        else if (i == 1)
        {
            return WisPass1();
        }
        else if (i == 2)
        {
            return ChaPass2();
        }
        else
        {
            return DexPass3();
        }
    }

    public override string GetStatFail(int i)
    {
        if (i == 0)
        {
            return StrFail0();
        }
        else if (i == 1)
        {
            return WisFail1();
        }
        else if (i == 2)
        {
            return ChaFail2();
        }
        else
        {
            return DexFail3();
        }
    }
}
