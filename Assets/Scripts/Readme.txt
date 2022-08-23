15 Mayis 2022:
--Oncelikle oyunu oynadim, oyundaki core mechanicleri su sekilde not aldim:

*Player hareketi: Slider seklinde olusan hareket sag ve sol kisimlara gittiginde kisitlaniyor,
bunun icin collider kullanabilirim

*Kamera: Kamera playerimizi takip ediyor ancak bastigimizda olusan kucuk bir movement sezdim.
Bu yuzden cinamachine yerine kendi hazirladigim follow camera sistemini kullanicagim

*Hucreler: Alinan her yeni hucre ilk kata geciyor. alinan kiyafetlerde yukaridan asagiya dolacak
sekilde siralaniyorlar.

*Elbise alma: Elbise aldiginda kendi hucresi doldugunda daha fazla elbise alamiyor. Sayet
baska bir hucre aldiginda oraya doluyor

*Engeller: Engeller iki sekilde bir tanesi kiyafetleri yok edebiliyor, Digeri hucreleri kiyafetlerle
birlikte yok ediyor.

/*-------------------------------------------*/

*Player hareketi tamamlandi
*Kamera hareketi tamamlandi
*Hucrelerin alinmasi tamamlandi
*Hucrelerin bir engele carptiginda yokedilmesi tamamlandi.

16 Mayis 2022:

--Oyunda core olarak halletmem gereken elbiseler ve bu elbiseler toplandigindaki yerlerinin degismesi kaldi.

*Elbise bulunup eklendi.
*Elbiseler su an icin belirttigim konuma alindigi takdirde gidiyor.

16 Mayis 2022:

*Elbiseler duzeltildi algoritma duzgun bir sekilde calismakta, elbiseler yukaridan asagiya girebilecegi slotlara sirasiyla giriyorlar.

--Elbiselerle birlikte core olarak diyebilecegim her sey tamam simdi oyun sonunu getirmem lazim:

1.sart kaybetme sarti, ne icin kaybedebilir:

*-kaybetme olarak tek gordugum yuksekliginin 1 oldugu vakitte obstacle elementine carpmasiyla olusuyor, Canvastan bir Ui hazirlayip bunu ekrana getiricem, 
ardindan kontrolleri devre disi birakip scene tekrari edilecek.

2.sart kazanma sarti, oyun sonuna gelindiginde bir skorel carpma goruyorum, oyunda genel olarak puan konusundan bahsedilmemis ama Cell objesinin icindeki 
oge sayisi kadar bir skorel carpim verilebilir, buna gorede o skorel carpana dogru transform lerp yapilabilir. Kazandigi takdirde diger Scene'e gecis sag-
lanacak.

--Kazanma ve kaybetme bittikten sonra yapilmasi gerekenler:

Animasyonlarin hazirlanmasi; bazi objelerin sekilleri degistirilip animasyon haline gelebilir

Renklendirme: Cevre rengi oldukca dusuk ve isiklandirmada bu konuda duzeltilebilir

/*------------------------------------------------------------------------------------------------------------------*/

-Kaybetmesini saglamak icin heightini almama gereke kalmadi cunku player olarak belirledigim obje obstacle a carptigi surece sorun yok. Ama yukaridan gelmis
bir nesneye carpmasi durumunda oyunu bastan baslamamasi icin heightinide kontrol ettirdim , boylece oyun buga girmeyecek.

-Bir start screene hazirladim, tap to play ve you level failed seklinde, bunlari lose screene ekledim.

-Animasyonlar ve renklendirme tamam.


17 Mayis 2022:

* Oyunum bitti ama su an oyunumda olmasini istedigim tek sey finish ekrani geldiginde elbiselerin saga ve sola gitmesi.

* Ayrica kamera ve golgeler iyilestirilebilir.

*Makas sistemi ve kiyafetler duzgun bir sekilde sistemi oturduldu, artik istenilen yerlere gidebiliyorlar.

*Oyun Bitti sadece 1 level daha eklemem lazim(2)

*Oyundaki tum buglari temizledim

*1.Bolum normal 2. bolum oyunu kaybettirmeye yonelik adimlarin gorulmesi icin , son olarakta 3.bolum oyun sonunu debuglayabilmek icin yapilmistir.



