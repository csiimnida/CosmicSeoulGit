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
        public float _playerHealth = 100;
    }

    public class PlayerPowerNomal
    {
        /// <summary>
        /// 강인한 힘
        /// 공격력	10%
        /// </summary>
        public int strong_strength = 0;
        /// <summary>
        /// 넘치는 활력
        /// 체력  	10%
        /// </summary>
        public int full_of_vitality = 0;
        ///<summary>
        /// 신속한 움직임
        /// 공격 속도	10%
        /// </summary>
        public int rapid_movement = 0;
        ///<summary>
        /// 신속한 움직임
        /// 이동 속도	10%
        /// </summary>
        public int nimble_legs = 0;
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
        public int Berserker = 0;
        /// <summary>
        /// 절대방어
        /// 체력	    20%
        /// </summary>
        public int absolute_defense = 0;
        ///<summary>
        /// 헤비급
        /// 공격력	25%
        /// 체력	    50%
        /// 공격 속도	-10%
        /// 이동 속도	-20%
        /// </summary>
        public int heavy_weight = 0;
        ///<summary>
        /// 스피드스터
        /// 이동 속도	30%
        /// </summary>
        public int speed_ster = 0;
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
        public int Warrior_Protection = 0;
        /// <summary>
        /// 명사수
        /// 공격력	10%
        /// 공격 속도	20%
        /// 이동 속도	-10%
        /// </summary>
        public int sharpshooter = 0;
    }
}
