var io = require('socket.io')({
	transports: ['websocket'],
});
io.attach(4567);  // 포트번호 설정 
console.log('127.0.0.1:4567 서버 실행');

var userName_list=[]            // player 이름 저장 리스트
var gameStrartingUserCount = 2; // 게임을 시작하는 player 숫자
var requestCount = 0;           // requestStart

io.on('connection', function(socket){
    console.log('클라이언트 접속');
    console.log('New connection from: ', socket.request.connection.remoteAddress);
  
    // 새로운 사용자 접속 이벤트
    socket.on('joinNewUser', (data)=>{
      socket.userName = data.userName;                      // 새로운 채팅 사용자의 nickname을 socket.username에 저장
      console.log('joinNewUser 이벤트 발생 : ', data);      // 클라이언트로부터 받은 데이터
  
      userName_list.push(data.userName);
      console.log('userName_list: ', userName_list);        // 사용자 이름 리스트 출력
      
      // 접속 사용자 숫자가 gameStrartingUserCount이면 클라이언트에게 'playGame' 이벤트 전송
      if(userName_list.length == gameStrartingUserCount){
        io.emit('playGame');
      }
    })
  
    // 클라이언트 접속 해지 이벤트
    socket.on('disconnect', (reason)=>{
      console.log(`${socket.userName} 접속 해제`)
      console.log('reason: ', reason);
  
      userName_list.pop(socket.userName);
      console.log('userName_list: ', userName_list);                // 사용자 이름 리스트 출력
  
      io.emit('disconnetUser', {userName: socket.userName})
    })
  });