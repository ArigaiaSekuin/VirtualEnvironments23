/*
C# Variables, Actors and Metadata for the Homer project:
Homer Examples
Homer - The Story Flow Editor.
Copyright (c)2021-2023. Open Lab s.r.l - Florence, Italy
Developer: Pupunzi (Matteo Bicocchi)

*/

namespace Homer {

public static class HomerVars {

    public static int Rugon_Mindset = 0;

    public static int Alveron_Mindset = 0;

    public static int ACTOR_SELF_EXTEEM = 0;

    public static string CMD = "text";

    public static string SCENE_TYPE = "text";

    public static int QUEST_TASK = 0;

    public static string DIALOGUE_NAME = "text";

    public static string CUT_SCENE_NAME = "text";

    public enum EXPRESSION_TYPE { IDLE,  ANGRY,  HAPPY };
    public static string EXPRESSION; 
}

public static class HomerActors {
    public enum Actors {GLORIA, PEPPINO, UN_NOME, THE_MISCHIEF_MAKER, GRUNTER_THE_GUARD, MYSTICO_MCFLOP, NARRATOR, GRAZIANO_RUGON, ALVERON, ACHILLES, TRIOPAS, AGAMENNON, PLAYER, PARIS, TROJANS, GREEKS, HOMER, ZEUS}

}

public static class HomerMeta {

    public enum NEW_METADATA {ANIMALE_GRIGIO, ANIMALE_ROTONDO}
    public enum Mood {NEUTRAL, HAPPY, VERY_HAPPY, SAD, ANGRY, AMAZED}
    public enum Expression {RELAXED, GRINNING, PENSIVE, FROWNING, CRYING, ENRAGED}
    public enum Balloon_Type {SPEECH, WHISPER, THOUGHT, SCREAM, SLEEP, SING_SONG}
    public enum Location {HOME, OUTSIDE, OFFICE, PARK, SEA, MOUNTAIN}
    public enum Camera_direction {CLOSE_UP, ANGLE_ON, OFF_SCREEN, FADE_OUT, FADE_IN, VOICE_OVER}
    public enum Lightining {NEW_LIGHTINING, KEY, BACK, PRACTICAL, HARD, SOFT, CHIAROSCURO}
    public enum FLOW_STATE {IDEA, NOTES, DRAFT, EDITOR, FINAL}
    public enum FixedTypes { NOTE, IMAGE }
}

public static class HomerLabels {

     public enum Label { NEW_LABEL_KEY, GENERAL }

}

}
