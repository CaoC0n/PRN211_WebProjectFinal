USE master
GO

CREATE DATABASE [TravelReview]
GO

USE [TravelReview]
GO

CREATE TABLE Users (
    UserID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	FirstName nvarchar(50),
	LastName nvarchar(50),
    Username nvarchar(50),
    Email nvarchar(255) NULL,
    [Password] nvarchar(50),
	Gender int null, 
	PhoneNumber varchar(50),
	Status int,
	[Role] int
);

CREATE TABLE Address (
    LocationID INT IDENTITY(1,1) PRIMARY KEY,
    LocationName VARCHAR(255),
    StreetAddress VARCHAR(255),
    [Image] nvarchar(255) NULL,
	[Description] nvarchar(max) NULL,
	DatePost date null
);

CREATE TABLE Foods (
    FoodID INT IDENTITY(1,1) PRIMARY KEY,
    LocationID INT FOREIGN KEY REFERENCES Address(LocationID),
    [Name] nvarchar(100) NULL,
    [Description] nvarchar(max) NULL,
	[Image] nvarchar(255) NULL,
	[Address] VARCHAR(255),
	Price int,
	ServerTime VARCHAR(50),
	DatePost date null
);

CREATE TABLE Reviews (
    ReviewID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    UserID INT FOREIGN KEY REFERENCES Users(UserID),
    LocationID INT FOREIGN KEY REFERENCES Address(LocationID),
    [Date] date NULL,
    [Description] nvarchar(max) NULL
);

INSERT INTO Address (LocationName, StreetAddress, Image, Description, DatePost)
VALUES 
('Ho Chi Minh Mausoleum', 'Ba Dinh District, Hanoi, VietNam', 'f-1.jpg', 'The President Ho Chi Minh Mausoleum is a mausoleum which serves as the resting place of Vietnamese revolutionary leader and President Ho Chi Minh in Hanoi, Vietnam. It is a large building located in the center of Ba Dinh Square, where Ho, Chairman of the Worker Party of Vietnam from 1951 until his death in 1969, read the Declaration of Independence on 2 September 1945, establishing the Democratic Republic of Vietnam. It is open to the public every morning except Monday.', '2023-05-15'),
('Ancient City Of Hanoi', 'East of Thang Long Imperial Citadel, extending to the banks of the Red River - now the northern and western areas of Hoan Kiem district.', 'f-2.jpg', 'The official extent of the Hanoi Old Quarter has been fixed by a 1995 decision from the Vietnamese Ministry of Construction: in the north it is limited by Hang Dau street, in the west by Phung Hung street, in the south by Hang Bong street, Hang Gai street, Cau Go street, and Hang Thung street, and in the east by Tran Quang Khai street and Tran Nhat Duat street. Several of the streets that were part of the historic urban area of Hanoi lie outside this region, which was determined for being most dense in historical streets and for having maintained its historical character best. The official Old Quarter is part of the Hoan Kiem District. Its total area is about 100 ha and it counts 76 streets distributed over 10 wards.', '2022-11-28'),
('Quoc Tu Giam Temple', '58 P. Quoc Tu Giam, Van Mieu, Dong Da, Ha Noi', 'f-3.jpg', 'The Temple of Literature is one of several temples in Vietnam which is dedicated to Confucius, sages, and scholars. The temple is located to the south of the Imperial Citadel of Thang Long. The various pavilions, halls, statues, and stelae of doctors are places where offering ceremonies, study sessions, and the strict exams of the Đai Viet took place. The temple is featured on the back of the 100,000 Vietnamese dong banknote. Just before the Tet Vietnamese New Year celebration, calligraphists will assemble outside the temple and write wishes in Chu Han. The art works are given away as gifts or are used as home decorations for special occasions.', '2022-11-28'),
('Imperial Citadel of Thang Long', '19c Hoang Dieu, Đien Bien, Ba Đinh, Ha Noi', 'f-4.jpg', 'Thang Long Imperial Citadel is an important cultural and historical heritage of Vietnam, located in the heart of Hanoi city. Built in the 11th century, Thang Long Imperial Citadel is one of the typical symbols of Vietnam ancient culture and has witnessed many ups and downs of the country history. Thang Long Imperial Citadel is not only an important tourist destination but also a cultural symbol of the country, expressing the pride and historical traditions of the Vietnamese people. It was recognized by UNESCO as a World Cultural Heritage in 2010, contributing to promoting understanding and respect for Vietnamese culture in the international community.', '2022-11-28'),
('Ta Hien Street', 'Hang Buom, Hoan Kiem district, Hanoi.', 'service-1.jpg', 'This is a place that combines the nostalgia of Trang An and the modernity of Hanoi today. During the day, Ta Hien Street is as nostalgic, peaceful and ancient as any of 36 streets in Ha Noi. In the evening, Ta Hien becomes more vibrant when the shops start to light up and tables and chairs are displayed. The streets were filled with people coming like a festival. The bustle in the evening can last until 1 - 2 am. On weekends, the number of visitors here increases, creating a special atmosphere of the city that never sleeps.', '2023-02-12'),
('Hanoi Pedestrian Street', 'Hoan Kiem district, Hanoi.', 'service-2.jpg', 'The walking street around Hoan Kiem Lake is the most vibrant street in Hanoi, always attracting a large number of people and tourists every weekend. Bringing the typical beauty of Hanoi, the street gradually becomes a tourist brand and meeting point for many young people and families. Hoan Kiem Lake walking street has a large space, connected to the area around the lake. Hoan Kiem and some streets in Hanoi Old Quarter such as: Dinh Tien Hoang, Le Thai To, Hang Khay, Le Lai, Le Thach, Trang Tien, Tran Nguyen Han, Dinh Liet, Gia Ngu, Cau Go... Streets Operating hours are on 3 weekends from 19:00 Friday to 24:00 Sunday.', '2020-11-08'),
('Dong Xuan Night Market', 'Dong Xuan ward, Hoan Kiem district, Hanoi.', 'service-3.jpg', 'Dong Xuan Market, also known as Cho Lon, is a large-scale market and has existed for hundreds of years. According to records, in 1804, the Nguyen Dynasty built a market south of the To Lich River to facilitate the docking of ships for trade. By 1889, after Thai Cuc Lake and To Lich River were filled, the French government cleared, planned and put all the shops into an empty lot in Dong Xuan ward. Like many other markets in the area. City, Dong Xuan market is open every day of the week, from 6am - 6pm. As for the food court at the market alley, it operates until dawn the next morning. In particular, on 3 weekends, the market will be open until 10:30 p.m. to serve the shopping and walking needs of tourists.', '2024-11-30'),
('West Lake', 'Northwest of Hanoi, Tay Ho district, Hanoi.', 'hotay.jpg', 'West Lake is known as one of the most attractive meeting spots in the Capital with beautiful landscape, romantic space and many fun and entertaining activities. Below are suggested 10 experiences you can refer to when visiting West Lake, Hanoi. West Lake flower valley is located at the intersection of Nhat Chieu and Tay Ho streets, only about 600m from the water park, so it is extremely convenient. Convenient for you to combine sightseeing. This destination impresses with countless colorful flowers such as chrysanthemums, lavender, roses... and many unique landscapes, so you can unleash your creativity and bring home beautiful check-in photos.', '2024-01-02'),
('Tran Quoc Pagoda', '46 Thanh Nien, Yen Phu, Tay Ho, Ha Noi.', 'chuatranquoc.jpg', 'Tran Quoc Pagoda is the most sacred ancient pagoda in Hanoi capital. Tran Quoc Tu is always crowded with Buddhists and tourists coming to visit and worship. The 1st and 15th of every month are the two times when the most visitors come to the temple. In addition, Lunar New Year is also the time when people gather at the temple. The pagoda will be open to visitors every day of the week, from 8 a.m. to 4 p.m. On the full moon day and first day of every month, the pagoda welcomes visitors from 6 a.m. to 8 p.m. Visitors can visit this temple at any time of the month.', '2021-06-03'),
('One Pillar Pagoda', 'Doi Can Ward, Ba Dinh District, Hanoi.', 'gl-6.jpg', 'One Pillar Pagoda is an ancient pagoda in Vietnam built during the reign of King Ly Thai Tong, also known by many different names such as Mat Pagoda, Lien Hoa Dai or Dien Huu Tu. During the Ly Dynasty, the pagoda was located on the land of Thanh Bao village, Quang Duc district, west of Thang Long Imperial Citadel. Today, the pagoda is in Ba Dinh district, located in the park behind Ong Ich Khiem street, next to the Ba Dinh Square complex and President Ho Chi Minh Mausoleum. Because it is located in the complex of Ba Dinh Square and Uncle Ho Mausoleum, the time the pagoda is open for visitors also depends on these two locations. Accordingly, the pagoda will welcome guests from 7:00 a.m. to 6:00 p.m. every day. The duration for each tour usually ranges from 1 - 3 hours. The pagoda does not collect ticket fees for Vietnamese citizens to visit, worship Buddha or worship. Particularly for foreign tourists, the ticket price to visit One Pillar Pagoda is 25,000 VND/person.', '2021-06-03'),
('Hanoi Opera House', '1 Trang Tien, Phan Chu Trinh, Hoan Kiem, Hanoi.', 'gl-1.jpg', 'The Opera House is located right at the majestic August Revolution Square. From the theater, visitors can easily visit famous tourist attractions of the Capital such as Hoan Kiem Lake, National History Museum, Hilton Hanoi Opera hotel or many shopping centers and entertainment venues. in another Hanoi center. Hanoi Opera House is a magnificent and magnificent architectural work, ranked as a National Monument. This place is associated with many important events of the Capital. The Opera House is one of the most prominent theaters in our country, famous for many academic art performance programs. The theater possesses unique architecture and is a famous tourist destination, attracting a large number of tourists to visit and check in when arriving in Hanoi.', '2022-10-15')


INSERT INTO Users (FirstName, LastName, Username, Email, [Password], Gender, PhoneNumber, [Status], [Role])
VALUES 
('John', 'Doe', 'user1', 'johndoe@example.com', '1', 1, '123456789', 0, 1),
('Jane', 'Doe', 'user2', 'janedoe@example.com', '1', 2, '987654321', 0, 1),
('Alice', 'Smith', 'user3', 'alice@example.com', '1', 2, '555555555', 0, 1);

INSERT INTO Foods (LocationID, [Name], [Description], [Image], [Address], price, ServerTime, DatePost) 
VALUES 
(8, 'Hot Rice Flour Rolls', 'Nowadays, finding a delicious and cheap banh cuon shop is not easy, not to mention combining both of these factors together. But at the banh cuon shop, alley 29 Yen Phu, you will find the perfect blend of delicious flavor and reasonable price. With a long history of operation, the shop carries with it memories of the old days. Banh cuon is made in the old style, making you feel the rich flavors of the past.', 'banhcuon.jpg', 'Alley 29 Thuy Khue, Tay Ho, Hanoi', 35, '6h30 – 10h', '2024-03-20'),
(8, 'Canned Chicken', 'Canned chicken, delicious West Lake dish for hungry afternoons. The wormwood chicken here is 1 whole chicken thigh, guaranteed to be delicious. Thigh meat is delicious, not crumbly like eating industrial chicken. The mugwort of retaurant is also delicious but not too bitter. If you have the chance, you should definitely try this dish.', 'gatan.jpg', 'No. 31 Lane 115 An Duong', 20, '7h-17h', '2024-03-20'),
(8, 'Hot Snail', 'An interesting and inseparable answer to what to eat in West Lake is Thuy Khue hot snail. Coming to the restaurant, although not large, the space is always full of warmth, creating a feeling of closeness and familiarity. As one of the delicious snail restaurants in Hanoi, the delicious and fresh bowl of boiled snails here makes you unable to resist enjoying it. In particular, the restaurant is also famous for stir-fried quail with tamarind and fried spring rolls, bringing diversity and appeal to diners.', 'ocluoc.jpg', '107 Thuy Khue, Tay Ho, Hanoi', 15, '7h30 – 22h', '2024-03-20'),
(6, 'Banh Khuc', 'Banh Khuc is one of delicious dishes in Hanoi Pedestrian Street that visitors should enjoy. Banh Khuc here is made from sticky, fragrant sticky rice, served with many different types of rolls: silk rolls, fish rolls or cinnamon rolls. This is also a delicious dish on Hoan Kiem Lake walking street that is loved by many international tourists.', 'banhkhuc.jpeg', '35 Cau Go, Hang Bac, Hoan Kiem District, Hanoi', 35, '6h – 23h', '2020-06-20'),
(6, 'Rib Rice', 'Referring to the top delicious dishes of Hoan Kiem Lake, you certainly cannot ignore rib rice at 47 Dao Duy Tu. The restaurant is open all day so you can come and enjoy it anytime. Each meal is also quite filling, including rice, cutlets or ribs, pickles and a bowl of soup. The restaurant space is airy and quite hygienic, always ensuring visitors the best experience.', 'comsuon.jpg', '47 Dao Duy Tu, Hoan Kiem, Hanoi', 70, '10h – 22h30', '2021-07-20'),
(6, 'Grilled Meat Skewers', 'On cold days in Hanoi, grilled meat skewers become a sold-out snack, attracting customers. In every corner of Hanoi, grilled meat skewers are everywhere. Among them, the famous restaurant is Xien Nuong & Banh Mi located on Luong Ngoc Quyen street, near Hoan Kiem Lake. Grilled meat skewers have long been a Ho Guom delicacy that has attracted generations of Hanoians because of the rich taste of spices mixed with the sweet aroma of meat. Especially the aroma stimulates the taste buds.', 'thitxien.jpeg', '40 Luong Ngoc Quyen, Hoan Kiem, Hanoi', 10, '6h30 – 10h', '2022-03-24')






