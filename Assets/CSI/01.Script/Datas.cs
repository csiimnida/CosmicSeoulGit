using UnityEngine;
public class Datas
{
    public byte _saveNum;
    public string _screen_name;
    public PlayerPowerNomal _playerPowerNomal;
    public PlayerPowerRare _playerPowerRare;
    public PlayerDataUnique _playerPowerUnique;
    public PlayerData _playerData;
    public Datas()
    {
        _saveNum = 0;
        _screen_name = "";
        _playerPowerNomal = new PlayerPowerNomal();
        _playerPowerRare = new PlayerPowerRare();
        _playerPowerUnique = new PlayerDataUnique();
        _playerData = new PlayerData();
    }

    public class PlayerData
    {
        public Vector3 _position;
    }

    public class PlayerPowerNomal
    {
        /// <summary>
        /// 강인한 힘
        /// 공격력	10%
        /// </summary>
        public Stats strong_strength = new Stats(10,0,0,0);
        /// <summary>
        /// 넘치는 활력
        /// 체력  	10%
        /// </summary>
        public Stats full_of_vitality = new Stats(0,10,0,0);
        ///<summary>
        /// 신속한 움직임
        /// 공격 속도	10%
        /// </summary>
        public Stats rapid_movement = new Stats(0,0,10,0);
        ///<summary>
        /// 신속한 움직임
        /// 이동 속도	10%
        /// </summary>
        public Stats nimble_legs = new Stats(0,0,0,10);
    }
    public class PlayerPowerRare
    {
        /// <summary>
        /// 버서커
        /// 공격력	20%
        /// 체력	    -60%
        /// 공격 속도	30%
        /// 이동 속도	30%
        /// </summary>
        public Stats Berserker = new Stats(20,-60,30,30);
        /// <summary>
        /// 절대방어
        /// 체력	    20%
        /// </summary>
        public Stats absolute_defense = new Stats(0,20,0,0);
        ///<summary>
        /// 헤비급
        /// 공격력	25%
        /// 체력	    50%
        /// 공격 속도	-10%
        /// 이동 속도	-20%
        /// </summary>
        public Stats heavy_weight = new Stats(25,50,-10,-20);
        ///<summary>
        /// 스피드스터
        /// 이동 속도	30%
        /// </summary>
        public Stats speed_ster = new Stats(0,0,0,30);
    }

    public class PlayerDataUnique
    {
        
        /// <summary>
        /// 전사의 가호
        /// 공격력	10%
        /// 체력	    10%
        /// 공격 속도	40%
        /// 이동 속도	10%
        /// </summary>
        public Stats Warrior_Protection = new Stats(10,10,40,10);
        /// <summary>
        /// 명사수
        /// 공격력	10%
        /// 공격 속도	20%
        /// 이동 속도	-10%
        /// </summary>
        public Stats sharpshooter = new Stats(10,0,20,-10);
    }


}
public class Stats
{
    public int Count;
    public float Attack_Power;
    public float Health;
    public float Attack_Speed;
    public float Move_Speed;

    public Stats(float attackPower,float health,float attackSpeed,float moveSpeed)
    {
        Count = 0;
        Attack_Power = attackPower;
        Health = health;
        Attack_Speed = attackSpeed;
        Move_Speed = moveSpeed;
        
    }
}
