using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    // Создаём Singleton для того чтобы легко обращатся к CutsceneManager через CutsceneManager.Instance.ПубличныйМетодКоторыйВамНужен()
    public static CutsceneManager Instance;

    // Лист из структур катсцен, в которых есть Key и Value которые в дальнейшем будут заполнятся в Dictionary "cutsceneDataBase"
    // Делаем мы это потому что даже публичный Dictionary не отображается в инспекторе
    [SerializeField] private List<CutsceneStruct> cutscenes = new List<CutsceneStruct>();

    // База данных содержащая все катсцены которые мы будем создавать, и в дальнейшем можем вытягивать наши катсцены по ключам
    // Так как наш Dictionary публичный и статичный мы можем обращатся к нему из любого скрипта вот так - CutsceneManager.cutsceneDataBase["Ключ нужной катсцены"]
    public static Dictionary<string, GameObject> cutsceneDataBase = new Dictionary<string, GameObject>();

    // Хранит в себе катсцену которая проигрывается в текущий момент, если ни одной катсцены сейчас не проигрывается - она равна null
    public static GameObject activeCutscene;

    private void Awake()
    {
        // Создаём Singleton
        Instance = this;

        // Вызываем метод инициализации базы данных с катсценами
        InitializeCutsceneDataBase();

        // Проходимся по всем катсценам и выключаем их (чтобы при запуске игры не запускались катсцены)
        foreach (var cutscene in cutsceneDataBase)
        {
            cutscene.Value.SetActive(false);
        }
    }

    // Метод в котором мы заполняем Dictionary cutsceneDataBase
    private void InitializeCutsceneDataBase()
    {
        // Перед заполнением на всякий случай очищаем нашу базу данных
        cutsceneDataBase.Clear();

        // Заполняем cutsceneDataBase ключами и значениями которые мы укажем в листе cutscenes
        for (int i = 0; i < cutscenes.Count; i++)
        {           
            cutsceneDataBase.Add(cutscenes[i].cutsceneKey, cutscenes[i].cutsceneObject);
        }
    }

    // Метод для включения катсцены по ключу
    public void StartCutscene(string cutsceneKey)
    {
        // Если cutsceneDataBase не содежит катсцены с cutsceneKey то упоминаем об этом в консоли и не выполняем весь остальной метод
        if (!cutsceneDataBase.ContainsKey(cutsceneKey)) 
        {
            Debug.LogError($"Катсцены c ключом \"{cutsceneKey}\" нету в cutsceneDataBase");
            return;
        } 

        // Если сейчас проигрывается катсцена и мы пытаемся вызвать в этот момент ЕЁ ЖЕ то просто обрываем выполнение метода
        if (activeCutscene != null)
        {
            if (activeCutscene == cutsceneDataBase[cutsceneKey])
            {
                return;
            }
        }

        // Присваиваем активную катсцену
        activeCutscene = cutsceneDataBase[cutsceneKey];

        // Выключаем все катсцены
        foreach (var cutscene in cutsceneDataBase)
        {
            cutscene.Value.SetActive(false);
        }

        // Включаем ту катсцену которую хотим вызвать
        cutsceneDataBase[cutsceneKey].SetActive(true);
    }

    // Метод который выключает текущую катсцену
    public void EndCutscene()
    {
        if (activeCutscene != null)
        {
            activeCutscene.SetActive(false);
            activeCutscene = null;
        }
    }
}

// Структура катсцен для листа, чтобы потом присваивать эти значения к Key и Value в Dictionary cutsceneDataBase
[System.Serializable]
public struct CutsceneStruct
{
    public string cutsceneKey;
    public GameObject cutsceneObject;
}