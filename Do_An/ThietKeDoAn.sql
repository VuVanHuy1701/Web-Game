create database DoAn_Web
go

use DoAn_Web
go

Create Table    KhachHang(
    MaKH    Int    Identity(1,1),
    HoTen    Nvarchar(50)    Not Null,
    TaiKhoan    Varchar(50)    Unique,
    Email    Varchar(100)    Unique,
    DiachiKH    Nvarchar(200),
    NgaySinh    DateTime,
    Constraint    Pk_KhachHang    Primary Key(MaKH)
)


Create Table Category
(
    MaCategory    Int    Identity(1,1),
    TenHangMuc    Nvarchar(50)    Not Null,
    Constraint Pk_Category Primary Key(MaCategory)
)
alter table Category add ghichu nvarchar(100);

Create Table StudioGame
(
    MaStudio    Int Identity(1,1),
    TenStudio    Nvarchar(50)    Not Null,
    DiaChi    Nvarchar(200),
    Email    Varchar(100)    Unique,
    Constraint    Pk_StudioGame Primary Key(MaStudio),
)

Create Table Game
(
    MaGame    Int    Identity(1,1),
    TenGame    Nvarchar(100)    Not Null,
	AnhBia    Varchar(100),
    GiaBan    Decimal(18,0)    Check(GiaBan>=0),
    MoTa    Nvarchar(Max),
    NgayCapNhat    DateTime,
    SoLuongTon    Int,
    MaCate    Int,
    MaStu    Int,
    Constraint    Pk_Game    Primary Key(MaGame),
    Constraint    Fk_Category    Foreign    Key(MaCate) References Category(MaCategory),
    Constraint    Fk_StudioGame    Foreign Key(MaStu) References    StudioGame(MaStudio)
)
create table Gametop(
	ten nvarchar(100) not null,
	anh Varchar(100),
	mieuta nvarchar(max),
)

ALTER TABLE Game
  ALTER COLUMN NgayCapNhat date;

Create Table    DonDatHang
(
    SoDH    Int Identity(1,1),
    MaKH    Int,
    Constraint    Pk_DonDatHang    Primary Key(SoDH),
    Constraint    Fk_KhachHang    Foreign    Key(MaKH)    References    KhachHang(MaKH)
)
Create Table    ChiTietDatHang
(
    SoDH    Int,
    MaGame    Int,
    DonGia Decimal(18,0)    Check(DonGia>=0),
    Constraint    Pk_ChiTietDatHang    Primary Key(SoDH,MaGame),
    Constraint    Fk_DonHang    Foreign    Key(SoDH)    References    DonDatHang(SoDH),
    Constraint    Fk_Game Foreign Key(MaGame)    References    Game(MaGame)
)
Create table Admin 
(
	ID INT PRIMARY KEY IDENTITY(1,1),
	UserAdmin varchar(30),
	PassAdmin varchar(30) not null,
)

select * from Admin

create table NewsPost(
    PostID int identity(1,1),
    PostName nvarchar(50),
    PostImg nvarchar(50),
    PostDesc nvarchar(max),
    dayUpdated date,
    Constraint    Pk_NewsPost    Primary Key(PostID),
)
alter table NewsPost 
 add PostNameFull nvarchar(200);

Create view Game_Category as
Select MaGame, TenGame, AnhBia, GiaBan, TenHangMuc
From Game inner join Category on Game.MaCate = Category.MaCategory
go

select * from KhachHang

-------------------------Thêm dữ liệu cho Category-----------------------------------
insert into Category values ('Action')
insert into Category values ('Role-playing')
insert into Category values ('Strategy')
insert into Category values ('Sport and Racing')
insert into Category values ('Simulation')
insert into Category values ('Adventure')
insert into Category values ('Free to play')

-------------------------Thêm dữ liệu cho Studio-----------------------------------
insert into StudioGame	values ('Bandai Namco Entertainment','Japan','123@gmail.com')
insert into StudioGame  values ('Sony Interactive Entertainment','USA','1234@gmail.com')
insert into StudioGame  values ('CD Projekt RED STUDIO','Polish','12345@gmail.com')
insert into StudioGame  values ('CapCom','Japan','123456@gmail.com')
insert into StudioGame  values ('Red Barrels','Canada','123457@gmail.com')

-------------------------Thêm dữ liệu cho Game-----------------------------------
---//-----//------//-------//--------//-----//-----------CATE 1----------//----//----//---------//-------//------------//--------//-----//------//

insert into Game values ('OUT LAST I','Outlast_1_300xx.jpg', 3,
'Hell is an experiment you cant survive in Outlast, 
a first-person survival horror game developed by veterans of some of the biggest game franchises in history.
As investigative journalist Miles Upshur, explore Mount Massive Asylum and try to survive long enough to discover its terrible secret... if you',
'2013/04/09',999,1,1);

insert into Game values ('Resident Evil Village','_Resident_Evil_Villagexx300.jpg', 20,
'Experience survival horror like never before in the 8th major installment in the Resident Evil franchise 
- Resident Evil Village. With detailed graphics,
intense first-person action and masterful storytelling, the terror has never felt more realistic.',
'2018/02/09',999,1,5);

insert into Game values ('Little Nightmares II','_Little_Nightmares_IIxx300.jpg', 10,
'Little Nightmares II is a suspense adventure game in which you play as Mono, 
a young boy trapped in a world that has been distorted by an evil transmission. 
Together with new friend Six, he sets out to discover the source of the Transmission.',
'2021/2/11',999,1,2);

insert into Game values ('GTFO','gtfo_300xx.jpg', 9,
'GTFO is an extreme cooperative horror shooter that throws you from gripping suspense to explosive action in a heartbeat. 
Stealth, strategy, and teamwork are necessary to survive in your deadly, underground prison. Work together or die together.',
'2021/12/10',999,1,1);

insert into Game values ('The Death | Thần Trùng','The_Death_Than_Trung_300xx.jpg', 3,
'The Death | Thần Trùng is a Viet Nam psychological horror adventure game made by three Vietnamese people from a tiny indie studio. The game takes place in Hanoi city in 2022.',
'2022/09/15',999,1,4);

insert into Game values ('God of War','God_of_War_4_cover_300xx.jpg', 29,
'His vengeance against the Gods of Olympus years behind him, Kratos now lives as a man in the realm of Norse Gods and monsters.
It is in this harsh, unforgiving world that he must fight to survive… and teach his son to do the same.',
'2022/01/14',999,1,1);

---//-----//------//-------//--------//-----//-----------CATE 2----------//----//----//---------//-------//------------//--------//-----//------//

insert into Game values ('THE WITCHER 3: WILD HUNT','Witcher_3_cover_artxx300.jpg', 8,
'You are Geralt of Rivia, mercenary monster slayer. Before you stands a war-torn, monster-infested continent you can explore at will. 
Your current contract? Tracking down Ciri — the Child of Prophecy, a living weapon that can alter the shape of the world.',
'2015/05/18',999,2,5);

insert into Game values ('ELDEN RING','edenring.jpg', 42,
'THE NEW FANTASY ACTION RPG. Rise, Tarnished, and be guided by grace to brandish the power of the Elden Ring and become an Elden Lord in the Lands Between.',
'2022/02/25',999,2,1);

insert into Game values ('KING OF SEA','kingofsea.jpg', 6,
'King of Seas is an ARPG adventure game set in a nautical pirate world. Embark on an epic adventure across the seven seas where you’ll discover lost islands and treasures,
fight rival pirates and menacing monsters, and become the most legendary pirate of all time!',
'2021/05/25',999,2,3);

---//-----//------//-------//--------//-----//-----------CATE 3----------//----//----//---------//-------//------------//--------//-----//------//

insert into Game values ('Football Manager 2023','football-manager-2023-300xx.jpg', 36,
'Build your dream squad, outsmart your rivals and experience the thrill of big European nights in the UEFA Champions League. Your journey towards footballing glory awaits.',
'2022/11/08',999,3,1);

insert into Game values ('Goose Goose Duck','Goose_Goose_Duck_300xx.jpg', 20,
'Goose, goose, DUCK? A game of social deduction where you and your fellow geese must work together to complete your mission.
Keep an eye out for those malicious Mallards and other birds, who have infiltrated your team and will do anything to stop you.',
'2021/10/04',999,3,3);

insert into Game values ('Rainbow Six® Siege','Tom_Clancys_Rainbow_Six®_Siege_300xx.jpg', 15,
'Tom Clancys Rainbow Six Siege is the latest installment of the acclaimed first-person shooter franchise developed by the renowned Ubisoft Montreal studio.',
'2022/12/01',999,3,2);

---//-----//------//-------//--------//-----//-----------CATE 4----------//----//----//---------//-------//------------//--------//-----//------//

insert into Game values ('Forza Horizon 5','Forza_Horizon_5300xx.jpg', 27,
'Your Ultimate Horizon Adventure awaits! Explore the vibrant open world landscapes of Mexico with limitless, fun driving action in the world’s greatest cars. 
Blast off to Hot Wheels Park and experience the most extreme tracks ever devised. Requires Forza Horizon 5 game, expansion sold separately.',
'2018/11/09',999,4,1);

insert into Game values ('Spider-Man Remastered','Spider-Man_PS4_cover_300xx.jpg', 25,
'In Marvel’s Spider-Man Remastered, the worlds of Peter Parker and Spider-Man collide in an original action-packed story. Play as an experienced Peter Parker, 
fighting big crime and iconic villains in Marvel’s New York. Web-swing through vibrant neighborhoods and defeat villains with epic takedowns...',
'2022/08/12',999,4,1);

insert into Game values ('FIFA 22','FIFA_22_300xx.png', 42,
'Powered by Football™, EA SPORTS™ FIFA 22 brings the game even closer to the real thing with fundamental gameplay advances and a new season of innovation across every mode.',
'2021/09/30',999,4,1);

---//-----//------//-------//--------//-----//-----------CATE 5----------//----//----//---------//-------//------------//--------//-----//------//

insert into Game values ('Call of Duty®','Call_of_Duty_Modern_Warfare_II_300xx.jpg', 65,
'Call of Duty®: Modern Warfare® II drops players into an unprecedented global conflict that features the return of the iconic Operators of Task Force 141.',
'2022/10/28',999,5,1);

insert into Game values ('Dead by Daylight','Dead_by_Daylight_300xx.jpg', 3,
'Dead by Daylight is a multiplayer (4vs1) horror game where one player takes on the role of the savage Killer,
and the other four players play as Survivors, trying to escape the Killer and avoid being caught and killed.',
'2016/06/14',999,5,1);

insert into Game values ('Raft','Raft_300xx.jpg', 5,
'Raft throws you and your friends into an epic oceanic adventure! Alone or together, players battle to survive a perilous voyage across a vast sea! Gather debris,
scavenge reefs and build your own floating home, but be wary of the man-eating sharks!',
'2022/06/20',999,5,1);

---//-----//------//-------//--------//-----//-----------CATE 6----------//----//----//---------//-------//------------//--------//-----//------//

insert into Game values ('HORIZON ZERO DAWN','horizonexx300.jpg', 16,
'Horizon Zero Dawn is a 2017 action role-playing game developed by Guerrilla Games and published by Sony Interactive Entertainment. 
The plot follows Aloy, a young hunter in a world overrun by machines, who sets out to uncover her past.',
'2020/07/08',999,6,3);

insert into Game values ('Grounded','Grounded_game_cover_art_300xx.jpg', 18,
'The world is a vast, beautiful and dangerous place – especially when you have been shrunk to the size of an ant.
Can you thrive alongside the hordes of giant insects, fighting to survive the perils of the backyard?',
'2022/09/27',999,6,1);

insert into Game values ('High On Life','High_On_Life_300xx.jpg', 20,
'From the mind of Justin Roiland comes High On Life. Humanity is being threatened by an alien cartel who wants to use them as drugs.
It’s up to you to rescue and partner with charismatic, talking guns, take down Garmantuous and his gang, and save the world!',
'2022/12/13',999,6,1);

---//-----//------//-------//--------//-----//-----------CATE 7----------//----//----//---------//-------//------------//--------//-----//------//

insert into Game values ('PUBG: BATTLEGROUNDS','battlegrounds_300xx.jpg', 0,
'Play PUBG: BATTLEGROUNDS for free. Land on strategic locations, loot weapons and supplies, and survive to become the last team standing across various, diverse Battlegrounds.
Squad up and join the Battlegrounds for the original Battle Royale experience that only PUBG: BATTLEGROUNDS can',
'2017/12/21',999,7,1);

insert into Game values ('Team Fortress 2','Team_Fortress_2_300xx.jpg', 0,
'Nine distinct classes provide a broad range of tactical abilities and personalities. Constantly updated with new game modes, maps, equipment and, most importantly, hats!',
'2007/10/10',999,7,1);

insert into Game values ('Destiny 2','Destiny_2_(artwork)_300xx.jpg', 0,
'Destiny 2 is an action MMO with a single evolving world that you and your friends can join anytime, anywhere, absolutely free.',
'2019/10/1',999,7,1);

-------------------------Thêm dữ liệu cho bài viết-----------------------------------

 insert into NewsPost values ('Elden Ring is...', 'atc1.jpg',
 'Developer Avalanche Software and publisher Warner Bros. Games has released a new gameplay showcase to highlight three different aspects of its
 upcoming wizarding RPG: the open world, combat, and the famed castles Room of Requirement. ',
 '2022/12/20','Elden Ring is 2022 Game Of The Year')

 insert into NewsPost values ('Lên sóng: Ưu đãi...', 'atc2.jpg', 
 'Ưu đãi Steam mùa đông đã LÊN SÓNG! Từ nay cho đến 1 giờ Việt Nam ngày 6/1, bạn sẽ thấy ưu đãi trên hàng ngàn trò chơi trong dịp khuyến mãi lớn nhất năm của chúng tôi.
 Sắm sửa cho bản thân hoặc bè bạn nào—bạn có thể tặng một trò chơi cụ thể hoặc thẻ quà tặng.
Còn với Giải thưởng Steam, nếu bạn đã đề cử cho trò chơi mình yêu thích vào 2022, giờ đã đến lúc để BẦU CHỌN rồi đó! Bầu chọn TẠI ĐÂY cho 11 hạng mục trước 0 giờ Việt Nam ngày 4/1; 
chúng tôi sẽ thông báo các trò chơi thắng cuộc sau đó một tiếng. ',
 '2022/12/23','Lên sóng: Ưu đãi Steam mùa đông!')

 insert into NewsPost values ('The Dead Island 2...', 'atc3.jpg', 
 'If you subscribe to the digital edition of Game Informer, you can now learn all about Dead Island 2. Following the cover reveal,
 our digital issue is now live to subscribers on web browsers, iPad/iPhone, and Android devices. Individual issues will be available for purchase this afternoon.
You can download the apps to view the issue by following this link. All of these digital options are included in a PowerUp Rewards Membership. ',
 '2020/3/8','The Dead Island 2 Digital Issue Is Now Live')

insert into NewsPost values ('Phát hành hàng đầu tháng...', 'atc4.jpg',
'Không khí nhộn nhịp đón chờ đợt Ưu đãi mùa đông đã ngập tràn, nhưng trước khi đi vào chi tiết, chúng tôi hân hạnh thông báo danh sách hàng đầu tháng 11 trên Steam. 
Như thường lệ, chúng tôi nhìn vào tất cả phát hành trong tháng, để tôn vinh 20 trò chơi cùng 5 DLC hàng đầu dựa trên doanh thu hai tuần đầu tiên. 
Chúng tôi cũng tổng hợp và vinh danh 5 trò chơi miễn phí hàng đầu, xếp theo số người chơi riêng biệt cao nhất sau khi ra mắt. ',
'2022/12/22','Phát hành hàng đầu tháng 11/2022')

insert into NewsPost values ('Pokemon New DLC', 'atc5.jpg',
'Developer Avalanche Software and publisher Warner Bros. Games has released a new gameplay showcase to highlight three different aspects of its upcoming
wizarding RPG: the open world, combat, and the famed castles Room of Requirement. ',
'2022/12/22','Pokemon New DLC')
