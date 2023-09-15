using System;

namespace VirusWarGameServer
{
	public enum PROTOCOL : short
	{
        BEGIN = 0,
        ENTER_GAME_ROOM,

        // 클라이언트의 이동 요청.
        PLAYER_MOVING,
        // 게임 종료.
        GAME_OVER = 10,
        //메시지 전송
        CHAT_MSG,
        END
    }
}
