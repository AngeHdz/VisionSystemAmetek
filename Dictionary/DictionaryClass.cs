using EmguClass;
using VisionSystemAmetek.ProcessWindows.UserForm;

namespace VisionSystemAmetek.Dictionary
{
    public static class DictionaryClass
    {
        public static IUserProcess GetPanel(TypeProcess type)
        {
            var actions = new Dictionary<Predicate<TypeProcess>, IUserProcess>
            {
                { t => t == TypeProcess.SmoothMedian, new SmoothMedianSet() },
                { t => t == TypeProcess.SmoothBlur, new SmoothBlurSet() },
                { t => t == TypeProcess.Canny, new CannySet() }
            };

            IUserProcess operation = actions.ToList().Find(d => d.Key(type)).Value;
            return operation;
        }
    }
}
