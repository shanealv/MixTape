using static MixTapeApp.Enumerations.Dynamics;

namespace MixTapeApp.Enumerations
{
    /// <summary>
    /// Here for show, might not even use.
    /// </summary>
    enum Dynamics
    {
        Pianissimo,
        Piano,
        MezzoPiano,
        MezzoForte,
        Forte,
        Fortissimo,
    }

    /// <summary>
    /// Extension methods for the Dynamics enumerations
    /// </summary>
    static class DynamicsExtensionMethods
    {
        public static string ToString(this Dynamics dynamic)
        {
            switch (dynamic)
            {
                case Pianissimo:
                    return "pp";
                case Piano:
                    return "p";
                case MezzoPiano:
                    return "mp";
                case MezzoForte:
                    return "mf";
                case Forte:
                    return "f";
                case Fortissimo:
                    return "ff";
                default:
                    return string.Empty;
            }
        }
    }
}
