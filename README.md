# JwtMusic Projesi

🎶  Bu projede bir DJ için modern bir web sitesi tasarlandı ve admin paneli aracılığıyla sitenin yönetimi sağlandı. Kullanıcıların DJ'in müziklerine erişebilmesi için platforma kayıt olmaları ve bir müzik paketi seçmeleri gerekmektedir. Seçilen pakete göre kullanıcılar ilgili müzik içeriklerine erişim sağlayabilir.

Bu proje, .NET 9 MVC teknolojisi kullanılarak geliştirildi. Repository Design Pattern uygulanarak N Katmanlı Mimari yapısı oluşturuldu. Identity ile kullanıcı işlemleri, JWT ile kimlik doğrulama süreçleri gerçekleştirildi.
Veritabanı işlemlerinde Entity Framework - Code First yaklaşımı tercih edilerek MSSQL veritabanı kullanıldı.
Doğrulama işlemleri için AutoMapper ve FluentValidation kütüphaneleri entegre edildi.

## ➸ Web Site

Kullanıcılar web sitesi üzerinden DJ'e ait bilgileri görüntüleyebilir.
Konser detayları, tanıtım videosu, hakkında sayfası, şarkılar ve iletişim bilgileri gibi çeşitli bölümler bulunmaktadır.

🎵 Şarkılar

   * Kullanıcılar giriş yapmadan tüm şarkıların listesini görebilir.

   * Ancak bir şarkıyı dinlemek istediklerinde sistem, önce kullanıcı girişi yapmalarını ister.

   * Eğer kullanıcı hesabı yoksa, kayıt sayfasına yönlendirilir.

   * Kayıt esnasında, kullanıcıya müzik paket seçenekleri ve her paketin içerikleri sunulur.

   * Kullanıcı tercih ettiği paketi seçerek kayıt işlemini tamamlar ve giriş sayfasına yönlendirilir.

   * Giriş yaptıktan sonra, kullanıcı yalnızca paket içeriğinde yer alan şarkıları dinleyebilir.

   * Eğer seçilen şarkı, kullanıcının paketi dahilinde değilse "Erişiminiz Bulunmamaktadır" uyarısı gösterilir.

 <details>

<summary>📌 JWT Konfigürasyonu (Tıklayınız) </summary>
   
> 
> 
> 1. Kullanıcının paket doğrulamasını yapabilmek için kullanıcı giriş işlemini gerçekleştirdiğinde JwtTokenHelper sınıfı ile Jwt Token üretilir ve bu token içerisinde kullanıcının paket bilgisi tutulur.
>
> 2. Token, tarayıcıya (örneğin localStorage) kaydedilir ve her istekte sunucuya gönderilir.
>
> 3. Kullanıcı bir şarkıya tıkladığında tarayıcıdan token alınır.
>
> 4. Token içerisinden kullanıcının Paket ID'si çözülür.
>
> 5. İlgili şarkının hangi pakete ait olduğu veritabanından alınır.
>
> 6. Şarkının ait olduğu paket ID ile token'daki paket ID karşılaştırılır.
>> Eğer eşleşiyorsa: şarkı çalınır.
>>
>> Eğer eşleşmiyorsa: kullanıcıya "Pakete dahil olmayan şarkı." uyarısı verilir.
> 
> 7. Her şarkı dinleme isteği Bearer Token ile doğrulanır.
>
> 8. Token doğrulama sırasında süresi geçmiş veya geçersiz token varsa kullanıcı erişemez.
> 
> 🧱 Kullanılan Yapılar
>> JwtTokenHelper sınıfı token üretme ve doğrulama işlemlerini yönetir.
>>
>> SongAccessController üzerinden şarkı çalma istekleri karşılanır ve erişim yetkileri kontrol edilir.
>>
>> UserLoginController kullanıcı girişi sonrası token üretimini ve yönlendirmeyi sağlar.
>>
</details>


## ➸ Admin Paneli

Web sitesindeki alanlar dinamik olarak yönetilebilir. Tüm alanların CRUD işlemleri gerçekleştirildi. FluentValidation kullanarak veri doğrulaması yapıldı.

* Müzikler menüsünde yeni müzik ekleme ve var olan müziği güncelleme işlemini sadece Admin rolüne sahip kullanıcı yapabilir.
 
   * Member rolündeki kullanıcı yeni müzik eklemeye çalıştığında 401(Unauthorized) sayfası ile uyarı verilir.
 
* Kullanıcılar menüsünde User rolüne sahip kullanıcılar listelenir. Güncelle butonu ile kullanıcının paket bilgisi değiştirilebilir.

* Paketler menüsünde, paketlere şarkılar çoklu bir şekilde atanabilir.


<details>
  
<summary>📌 SeedUser ve SeedRole Oluşturma Açıklaması (Tıklayınız) </summary>

>
> 1. Admin paneli için Admin ve Member kullanıcıları SeedData yöntemiyle oluşturuldu. 
>
> 2. Bu projede uygulama ilk başlatıldığında bazı ön tanımlı roller ve örnek kullanıcılar oluşturulmaktadır. Bu işlemler, sistemin düzgün çalışabilmesi ve test amaçlı kullanımlar için gereklidir.

>> * SeedRoles.InitializeAsync() metodu şunları yapar:
  >>
  >>    * Tanımlı roller: "Admin", "Member", "User"
  >>
  >>    * Her rol için sistemde mevcut olup olmadığı kontrol edilir.
  >>
  >>    * Eğer rol yoksa, RoleManager yardımıyla oluşturulur.
  >> 
  >>    * 💡 Amaç: Uygulamada rol bazlı yetkilendirme yapılabilmesi için gerekli rollerin önceden tanımlanması.
>>
>> * CreateAdminUserAsync()
>>   
>>   * Eğer admin mail adresine sahip kullanıcı yoksa:
>>
>>   * Yeni bir admin kullanıcı (admin) oluşturulur.
>>
>>    * Şifre: "Admin123!"
>>
>>   * Bu kullanıcıya "Admin" rolü atanır.
>>
>> * CreateMemberUserAsync()
>>
>>   * Eğer member mail adresine sahip kullanıcı yoksa:
>>
>>   * Yeni bir üye kullanıcı (member) oluşturulur.
>>
>>   * Şifre: "Member123!"
>>
>>   * Bu kullanıcıya "Member" rolü atanır.
>> 
>>   * 💡 Amaç: Sistem başlatıldığında örnek kullanıcıların sisteme giriş yapabilmesini ve rol tabanlı testlerin yapılabilmesini sağlamak.
>>
>> * Bu yapı sayesinde:
>>
>>    * Rol tabanlı erişim sistemi önceden hazır hâle gelir.
>>
>>    * Geliştirme/test sürecinde kullanıcı oluşturma zahmeti ortadan kalkar.
</details>

## ✨ Görseller

![1](https://github.com/user-attachments/assets/9b79344f-9edf-4361-9d74-fbee79c6cad0)
![2](https://github.com/user-attachments/assets/a5276694-f07c-4dbc-96c6-a94ce1988449)
![3](https://github.com/user-attachments/assets/f8e9e648-fdb3-4964-91d9-8883e8450171)
![4](https://github.com/user-attachments/assets/978fe54c-5292-4d7b-8141-7d4edaf3f9d0)
![5](https://github.com/user-attachments/assets/72f48b03-253a-4eb1-a14c-29006e61602a)
![6](https://github.com/user-attachments/assets/7ada8b4d-1a97-438a-97ef-b10a2a388a87)

![userlogin](https://github.com/user-attachments/assets/578d9d7f-5331-424a-9610-39fde41dd535)
![userregister](https://github.com/user-attachments/assets/b66ee67a-17f2-43b6-ba57-c894bd2d4bf6)

![adminlogin](https://github.com/user-attachments/assets/d357450e-da01-4c23-99c3-c6d64f4d885c)

![7](https://github.com/user-attachments/assets/29048eab-f6f9-438a-bbcc-22e94190d852)
![8](https://github.com/user-attachments/assets/bb50a323-8c25-4a39-a709-a7d27679a783)
![9](https://github.com/user-attachments/assets/7eaea1da-546b-41c7-bbdd-b91a25a35056)
![10](https://github.com/user-attachments/assets/804876b8-f7dd-4c97-ab4f-b2d342be7d80)
![11](https://github.com/user-attachments/assets/02976127-593c-4b4d-a0e7-49e2cf0b8b2c)
![12](https://github.com/user-attachments/assets/ae3d930c-b863-4149-9c2a-e8fa10ca09c5)
![13](https://github.com/user-attachments/assets/17326f96-d4c0-4ea3-b26a-28a98ef41d4a)
![14](https://github.com/user-attachments/assets/162712dd-f31e-49b1-85e6-691c761f0821)
![15](https://github.com/user-attachments/assets/c384edbc-d8df-4191-b51f-5e3c20b57dec)
![16](https://github.com/user-attachments/assets/da55823a-ac6d-48e9-a1ec-d67eddf28e2e)
![17](https://github.com/user-attachments/assets/d3321455-7866-4f21-b1f4-a97edb121c25)
![18](https://github.com/user-attachments/assets/1f07f209-89df-4b88-8c30-c0852fd031c6)
![19](https://github.com/user-attachments/assets/116eef54-964d-4bdf-b2c4-6f87cd24a4c4)
![20](https://github.com/user-attachments/assets/7ed97fdf-4d3c-4720-9b3e-9346cec6a9d1)
![21](https://github.com/user-attachments/assets/e0cd78ed-52b7-4ad9-8be5-a2213f327e05)







