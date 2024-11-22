using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance = null;
    private static bool IsDestroyed = false;

    public static T Instance
    {
        get
        {
            if (IsDestroyed)
                _instance = null;

            if (_instance == null)
            {
                print("생성 완");
                _instance = GameObject.FindAnyObjectByType<T>();

                if (_instance == null)
                    Debug.LogError($"{typeof(T).Name} singleton is not exist");
                else
                    IsDestroyed = false;

                DontDestroyOnLoad(_instance.transform.root.gameObject);
                print("부셔지지 않아");

            }
            print("전환");
            return _instance;
        }
    }

    private void OnDisable()
    {
        IsDestroyed = true;
    }
}
