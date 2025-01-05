using ZhXun;

namespace ZhengHua
{
    /// <summary>
    /// 終點物件
    /// </summary>
    public class GameEndObject : InteracitiveObject
    {
        
        public override void Execute()
        {
            if(PlayerManager.Instance.GetCollectionCount(CollectionEnum.TureSucceedKey) == 5)
            {
                PlayerManager.Instance.ending = EndingEnum.TureSucceed;
            }
            else
            {
                PlayerManager.Instance.ending = EndingEnum.NormalSucceed;
            }
            
            GameOverManager.Instance.GameOver();
        }
    }
}
