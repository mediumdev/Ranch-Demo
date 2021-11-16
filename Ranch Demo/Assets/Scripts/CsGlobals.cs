using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsGlobals : MonoBehaviour
{
    public GameObject TRACTOR; //трактор
    public AudioManager AUDIO_MANAGER; //audio manager
    public GameObject GUI_MANAGER; //gui manager
    public int LEVEL; //текущий уровень
    public int HEALTH; //здоровье трактора
    public int DAMAGE; //урон от столкновений
    public int MAX_HEALTH; //максимальное здоровье трактора
    public int SHEEP_COUNT; //количество собраных овец
    public int SHEEP_NUM_NEXT_LEVEL; //число собраных овец для перехода на следующий уровень
    public float BEHIND_DISTANCE; //дистанция на сколько должен уехать трактор от объекта чтоб объект удалился
    public float DELETE_DISTANCE; //дистанция от трактора до объекта чтоб объект удалился
    public float TRACTOR_DETECT_DISTANCE; //дистанция от овцы до трактора, когда овца начнет убегать
    public float SHEEP_SPEED; //скорость овцы
    public bool IS_RESTARTING; //включена ли анимация перед перезагрузкой уровня
    public int TRACK_LENGTH; //длинна трассы которая уже сгенерировалась
    public float GROUND_SIZE; //размер тайла травы
    public float ADD_SPEED; //на сколько повышается скорость трактора при получении уровня
    public float ACCELERATE; //значение постепенного ускорения после получения уровня
    public float TRACK_WIDTH; //ширина дороги
    public int HEALTH_UP; //сколько здоровья пополняют аптечки
    public bool SLOWMOTION; //активно ли замедление
    public float SLOWMOTION_VALUE; //насколько замедляет слоумо, 1 - нормальная скорость
    public float SLOWMOTION_AMOUNT; //сколько времени длится замедление в секундах

    void Awake()
    {
        LEVEL = 1; //текущий уровень
        HEALTH = 0; //здоровье трактора
        MAX_HEALTH = 100; //максимальное здоровье трактора
        DAMAGE = 5; //урон от столкновений
        SHEEP_NUM_NEXT_LEVEL = 50; //число собраных овец для перехода на следующий уровень
        BEHIND_DISTANCE = 10f; //дистанция на сколько должен уехать трактор от объекта чтоб объект удалился
        DELETE_DISTANCE = 300f; //дистанция от трактора до объекта чтоб объект удалился
        TRACTOR_DETECT_DISTANCE = 3f; //дистанция от овцы до трактора, когда овца начнет убегать
        SHEEP_SPEED = 80f; //скорость овцы
        GROUND_SIZE = 100f; //размер тайла травы
        ADD_SPEED = 2.5f; //на сколько повышается скорость трактора при получении уровня
        ACCELERATE = 0.1f; //значение постепенного ускорения после получения уровня
        TRACK_WIDTH = 15f; //ширина дороги
        HEALTH_UP = 25; //сколько здоровья пополняют аптечки
        SLOWMOTION_VALUE = 0.3f; //насколько замедляет слоумо, 1 - нормальная 
        SLOWMOTION_AMOUNT = 3f; //сколько времени длится замедление в секундах
    }

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.targetFrameRate = 60;
        AUDIO_MANAGER.MusicCountryPlay();
    }

    void Update()
    {
        
    }
}
