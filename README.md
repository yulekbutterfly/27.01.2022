# 27.01.2022
<h1>Описание проекта </h1>
<h1>  Работу выполняют Смирнова Юлия и Щербакова Вероника </h1>

<br> Первое окно проекта-авторизация. <br>
![image](https://user-images.githubusercontent.com/98512778/155681590-851205ef-c366-4258-b507-4578417bfe60.png)

<br> При верном заполнении логина и пароля в окне авторизации, открывается главный экран с возможностью просмотреть список сотрудников, клиентов, товаров и информацию об аренде. <br>
![image](https://user-images.githubusercontent.com/98512778/155682018-06bb0689-0f85-446f-b822-0bc5dfb1edd8.png)

<br> Окно списка работников вмещает в себя все необходимые данные о работниках. Информация выгружена из базы данных. Присутствует фильтрация поиска, добавление нового сотрудника и возможность прикрепить фотографию. При двойном клике по сотруднику открывается окно изменения данных выбранного сотрудника. .<br> 
![image](https://user-images.githubusercontent.com/98512778/171837762-aafe760a-b3b9-4f54-abd3-1e38823c6f9b.png)

<br>Изменение выбранного сотрудника.<br>
![image](https://user-images.githubusercontent.com/98512778/171837985-241aa297-523f-485c-b8b5-6c5b087df6f2.png)
![image](https://user-images.githubusercontent.com/98512778/171838187-be8c7fc0-1019-476e-99ee-05625cc81055.png)
![image](https://user-images.githubusercontent.com/98512778/171838237-1be5296f-f94b-4eec-82cd-07ee7585326f.png)


<br>Добавление нового сотрудника.<br>
<br>В данном окне возникало много проблем с заполнением данных сотрудника. В проекте используется валидация на правильность написания почты(валидация пропускает почту только с использованием "@", только латинских букв, точки) логина(только латинские буквы), (ФИО может использоваться только кирилица) Вставка пробелов и спецсимволов в данные сотрудника стала невозможной.<br>
![image](https://user-images.githubusercontent.com/98512778/155687037-6591a6ee-f123-4f76-857c-40273ff13ece.png)
![image](https://user-images.githubusercontent.com/98512778/171839014-f48ba91c-68a0-4195-bb1b-0f9408c0d47d.png)
![image](https://user-images.githubusercontent.com/98512778/171839066-a5222772-653b-42ab-8668-f22108eaea9b.png)


 <br>Фильтрация списка сотрудников представлена ниже.<br>
![image](https://user-images.githubusercontent.com/98512778/155690269-fae4ce1f-768e-466f-8011-86fc7d8bd41d.png)
![image](https://user-images.githubusercontent.com/98512778/155690301-8c7065a2-6615-4acb-a50d-6ccab6f28d43.png)
![image](https://user-images.githubusercontent.com/98512778/155690322-31bf90f5-135f-48be-a0f7-f1ab163e4675.png)
![image](https://user-images.githubusercontent.com/98512778/155690531-f6cb7ba6-affc-41b1-856e-fbf67b8722d3.png)

<br>Окно списка клиентов содержит необходимую информацию для работы с данными.<br>
<br>Для удобного поиска необходимого клиента из списка, используется фильтрация(по имени, фамилии) и поиск <br>
![image](https://user-images.githubusercontent.com/98512778/171839821-95ed97a7-caac-4b31-b81f-3d09ca7b1106.png)
![image](https://user-images.githubusercontent.com/98512778/171840089-2a6189e7-9634-42ae-9e36-3fde5db26e6f.png)
![image](https://user-images.githubusercontent.com/98512778/171840155-047c4810-889f-4072-9aee-18fc980e5b78.png)

<br>Как и в окне со списком сотрудников, двоной клик по клиенту из списка выводит пользователя на окно изменения клиента, в котором также применена валидация и ограничения на заполнения данных о клиенте.<br>
![image](https://user-images.githubusercontent.com/98512778/155682782-8134b680-d8b4-4b13-8640-1a8a1d4856b5.png)
![image](https://user-images.githubusercontent.com/98512778/171839568-b1513f0e-df65-4dda-b6de-2b68c54091df.png)

<br> Окно с добавлением нового клиента, в котором необходимо заполнить данные о клиенте. Добавленная информация о новом клиенте сразу переходит в список всех клиентов окна "Клиенты" и в базу данных, привязанную к проекту.<br>
![image](https://user-images.githubusercontent.com/98512778/160103224-81e3aad3-e714-4c14-8c43-a56132475e51.png)
![image](https://user-images.githubusercontent.com/98512778/171842167-e10e8228-6118-4dc8-8531-4373d2c75054.png)
![image](https://user-images.githubusercontent.com/98512778/171842356-2f4b5fec-3734-46c3-9818-abd97beb453e.png)

<br>Список товаров содержит себе информацию о наименованиях, ценах, наличие на складе товаров. Работает поиск необходимого товара через поисковую строку, также имеется фильтрация.<br>
![image](https://user-images.githubusercontent.com/98512778/155682971-fc2c0b8f-4025-4b9d-ac13-159973df3d09.png)
![image](https://user-images.githubusercontent.com/98512778/171841040-067b037c-8f56-4d83-b32d-a00bfe322b2b.png)
![image](https://user-images.githubusercontent.com/98512778/171841097-31a55dc3-9e30-4b79-83ec-7c09b4135ad1.png)
![image](https://user-images.githubusercontent.com/98512778/171841165-bd388aa5-757b-4b2e-8b6b-8c53d3627dfe.png)

<br>Окно с добавлением товара. <br>
![image](https://user-images.githubusercontent.com/98512778/160104757-89fb0528-3ade-4e61-a515-e70c6fcd9a16.png)
![image](https://user-images.githubusercontent.com/98512778/171843575-47ec4d1f-6334-4f14-ab17-5167527d5cad.png)

<br>Аналогично, по двойному клику на товар из списка, окно переходит на изменение товара.<br>
![image](https://user-images.githubusercontent.com/98512778/171841499-22d82eda-dc6e-4437-914b-be83faf1d8d4.png)

<br>Окно списка арендованных товаров.<br>
![image](https://user-images.githubusercontent.com/98512778/171842457-acf4ea42-8eb7-480a-a404-126cf32e943f.png)
<br>Оформление товара в аренду: учитывая товар(стоимость его аренды в день) и количество дней, на которое арендован товар, автоматически рассчитывается стоимость аренды.<br>
![image](https://user-images.githubusercontent.com/98512778/171842559-1441a3aa-c001-4abb-b193-0a645ee5e85a.png)
![image](https://user-images.githubusercontent.com/98512778/171843222-1094785c-742a-4661-8843-0ff42d3924ac.png)

<br>При выборе арендованного товара из списка, появляется кнопка "Вернуть товар". После выбора даты возврата автоматически подсчитывается и выводится итоговая стоимость аренды товара.<br>
![image](https://user-images.githubusercontent.com/98512778/171843869-ee3ac885-7659-4226-828d-418f4a853956.png)
![image](https://user-images.githubusercontent.com/98512778/171844382-d8978202-2b44-4f83-afe9-c9635d910497.png)


