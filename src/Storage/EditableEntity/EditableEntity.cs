namespace Storage
{
    public abstract class EditableEntity : IIdentificable
    {
        protected EditableEntity() { }

        public abstract int Id { get; set; }

        public virtual bool IsNew()
        {
            return Id == 0;
        }
    }
}
