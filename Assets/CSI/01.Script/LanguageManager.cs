using UnityEngine.Events;

public class LanguageManager : MonoSingleton<LanguageManager>
{
    public event UnityAction<_languageType> OnLanguageChanged;
    private _languageType nowLanguageType;

    public _languageType language
    {
        get
        {
            return nowLanguageType;
        }
        set
        {
            OnLanguageChanged?.Invoke(value);
            nowLanguageType = value;
        }
    }

}
public enum _languageType
{
    Eng,Ko
}