using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CsGlobals : MonoBehaviour
{
    public GameObject TRACTOR; //�������
    public AudioManager AUDIO_MANAGER; //audio manager
    public GameObject GUI_MANAGER; //gui manager
    public int LEVEL; //������� �������
    public int HEALTH; //�������� ��������
    public int DAMAGE; //���� �� ������������
    public int MAX_HEALTH; //������������ �������� ��������
    public int SHEEP_COUNT; //���������� �������� ����
    public int SHEEP_NUM_NEXT_LEVEL; //����� �������� ���� ��� �������� �� ��������� �������
    public float BEHIND_DISTANCE; //��������� �� ������� ������ ������ ������� �� ������� ���� ������ ��������
    public float DELETE_DISTANCE; //��������� �� �������� �� ������� ���� ������ ��������
    public float TRACTOR_DETECT_DISTANCE; //��������� �� ���� �� ��������, ����� ���� ������ �������
    public float SHEEP_SPEED; //�������� ����
    public bool IS_RESTARTING; //�������� �� �������� ����� ������������� ������
    public int TRACK_LENGTH; //������ ������ ������� ��� ���������������
    public float GROUND_SIZE; //������ ����� �����
    public float ADD_SPEED; //�� ������� ���������� �������� �������� ��� ��������� ������
    public float ACCELERATE; //�������� ������������ ��������� ����� ��������� ������
    public float TRACK_WIDTH; //������ ������
    public int HEALTH_UP; //������� �������� ��������� �������
    public bool SLOWMOTION; //������� �� ����������
    public float SLOWMOTION_VALUE; //��������� ��������� ������, 1 - ���������� ��������
    public float SLOWMOTION_AMOUNT; //������� ������� ������ ���������� � ��������

    void Awake()
    {
        LEVEL = 1; //������� �������
        HEALTH = 0; //�������� ��������
        MAX_HEALTH = 100; //������������ �������� ��������
        DAMAGE = 5; //���� �� ������������
        SHEEP_NUM_NEXT_LEVEL = 50; //����� �������� ���� ��� �������� �� ��������� �������
        BEHIND_DISTANCE = 10f; //��������� �� ������� ������ ������ ������� �� ������� ���� ������ ��������
        DELETE_DISTANCE = 300f; //��������� �� �������� �� ������� ���� ������ ��������
        TRACTOR_DETECT_DISTANCE = 3f; //��������� �� ���� �� ��������, ����� ���� ������ �������
        SHEEP_SPEED = 80f; //�������� ����
        GROUND_SIZE = 100f; //������ ����� �����
        ADD_SPEED = 2.5f; //�� ������� ���������� �������� �������� ��� ��������� ������
        ACCELERATE = 0.1f; //�������� ������������ ��������� ����� ��������� ������
        TRACK_WIDTH = 15f; //������ ������
        HEALTH_UP = 25; //������� �������� ��������� �������
        SLOWMOTION_VALUE = 0.3f; //��������� ��������� ������, 1 - ���������� 
        SLOWMOTION_AMOUNT = 3f; //������� ������� ������ ���������� � ��������
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
