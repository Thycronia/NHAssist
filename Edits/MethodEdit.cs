namespace NHAssist.Edits
{
    public abstract class MethodEdit
    {
        public abstract bool ShouldApply { get; }
        public abstract void Apply();
        public virtual bool ShouldReApply => false;
        public virtual void ReApply() { }
    }
}

