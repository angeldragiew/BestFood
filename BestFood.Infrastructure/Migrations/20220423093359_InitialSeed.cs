using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BestFood.Infrastructure.Data.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8881f953-e7cc-4d0d-8937-9a74413e60c5", "bf92c9a9-a34d-4d04-ad50-4cc3f790ccb5", "Administrator", "ADMINISTRATOR" },
                    { "df578c9e-41dc-48e6-b352-5f4f33577c63", "1e802d12-994d-4c3f-99a0-91b8ff032857", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bcc9e639-b998-466b-8d67-5e7dda1dfe5a", 0, null, "472d1614-7386-4f0b-a1e8-b84723705567", "myadmin@gmail.com", false, null, null, false, null, "MYADMIN@GMAIL.COM", "MYADMIN", "AQAAAAEAACcQAAAAEMtV0yGNfGvT2o9zL9vlj1gkBYHEeLqMsKTNIXEzjwf4EizpLmjDrc1+kAohO7ZhPA==", null, false, "6bc9710e-d106-4b59-9dd2-62528314f2f9", false, "myadmin" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Image", "Name" },
                values: new object[,]
                {
                    { 1, "https://insanelygoodrecipes.com/wp-content/uploads/2020/05/Burger-with-fries-1024x536.png", "Burgers" },
                    { 2, "https://static.toiimg.com/photo/msid-87930581/87930581.jpg?211826", "Pizza" },
                    { 3, "https://t4.ftcdn.net/jpg/02/58/85/85/360_F_258858591_9cHoK7D35fpe4IO1JPyjXyuDV0HUMPSM.jpg", "Doner" },
                    { 4, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-191112-risotto-rice-0151-landscape-pf-1574723947.jpg", "Rissoto" },
                    { 5, "https://roseandsteinrestaurant.eu/wp-content/uploads/2016/12/ham-and-cheese-toast.jpg", "Toasts" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[,]
                {
                    { "0ad836b1-0b01-4b4a-ba36-9ded54ebaa85", "Tomato Sauce", 1 },
                    { "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb", "Onion", 3 },
                    { "0f1fa492-6a74-4b89-bde7-0f8d73d66277", "Chili Sauce", 1 },
                    { "20f84ff4-662d-4f0a-bc66-e9170c215a2a", "Tomato", 3 },
                    { "256a3217-f445-436e-b763-26829df121c6", "Mayonnaise", 1 },
                    { "2a63b060-acc5-41ad-844d-31209d33fa10", "Cucumber", 3 },
                    { "2f723a91-bc11-4104-bb01-6d4ebbc60fc5", "Ham", 2 },
                    { "33458ae4-b21f-4c39-8dff-44e87844a6a2", "Garlic Sauce", 1 },
                    { "392ff29a-68b8-4c7c-81d6-a5deb6d5a0c2", "Spinach", 3 },
                    { "4762b0c6-1d7f-468a-b4a9-a71d8b1c20f2", "White Cheese", 4 },
                    { "4e3b02ca-c436-4827-bc1d-6a283ba44a54", "Breaded Chicken", 2 },
                    { "53d5a668-8b04-45d3-be64-60e8ae439894", "Minced Meatball", 2 },
                    { "55fc746a-0a85-4923-a3ce-7a8beb914370", "Chicken fillet", 2 },
                    { "58fbb498-4393-41d2-a0e7-d0c364a36cc5", "Yellow Cheese", 4 },
                    { "5bb1a785-d1f7-4c2d-9da5-cf456df1bfaa", "Spicy Red Pepper", 3 },
                    { "5e27ab2b-8ed1-4f3b-87bd-cc52394088b4", "Mozzarella", 4 },
                    { "68f92dc1-85aa-4876-b86a-8ed4313deaae", "Cornflake Chicken", 2 },
                    { "6d1898d5-e4e5-4c4e-aed5-a9208b1ccf2b", "Pork Meatball", 2 },
                    { "71a2378d-74de-4c9a-a64b-237820a5b6b9", "Parmesan", 4 },
                    { "813bde29-b392-4c16-9a3f-65734d667b08", "Lettuce", 3 },
                    { "84def27a-0f81-4532-9907-1645aa7ee027", "Pork Loin", 2 },
                    { "8b596d55-2f13-45c0-80e3-b023434a14df", "Prosciutto", 2 },
                    { "8eb5383e-2440-4075-8aab-a774351a6153", "Bacon", 2 },
                    { "9ad3222f-77f7-4d4e-b9a3-66030e993e67", "Cheddar", 4 },
                    { "a3b2844c-a654-40cd-8045-e93d89826173", "Basil", 3 },
                    { "b1b16da7-738b-4211-a5e2-b8f6f62cd986", "Butter", 4 },
                    { "b372fe32-ee80-4d63-9019-9e9d9c87cd99", "Ground Beef", 2 },
                    { "b48f7dc6-4077-4bfb-8ed4-8f4e8d616908", "Cabbage", 3 },
                    { "b8ae6779-3469-4669-89f2-932b49d46fdc", "Corn", 3 },
                    { "bb1979e9-4c7b-412c-9e84-4598bfa0524e", "Sausage", 2 },
                    { "c20d21eb-326f-4011-b8ba-058399d972c6", "Pepperoni", 2 },
                    { "c751debf-36b1-4801-af56-8c9096f34309", "Pork", 2 },
                    { "d9979ac9-3401-4257-aded-cc37edd3becb", "Ketchup", 1 },
                    { "e4726844-83be-4631-8adb-b4e0ed0e4145", "Mustard", 1 }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name", "Type" },
                values: new object[,]
                {
                    { "e7791135-4cd6-4c94-afe9-1867dc19c338", "Chicken", 2 },
                    { "e9bf191c-3475-4240-885c-19daba91ca80", "Bell Peppers", 3 },
                    { "e9fbd357-86b4-4f6d-9368-c6434b7a318f", "Arugula", 3 },
                    { "f6903024-2ae3-403e-b7f4-a5cf074e4af7", "Burger Sauce", 1 },
                    { "f6dec5d8-15c5-4074-afa9-0b218f18a5f3", "Beef Meatball", 2 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8881f953-e7cc-4d0d-8937-9a74413e60c5", "bcc9e639-b998-466b-8d67-5e7dda1dfe5a" });

            migrationBuilder.InsertData(
                table: "CategoryIngredients",
                columns: new[] { "CategoryId", "IngredientId" },
                values: new object[,]
                {
                    { 1, "0ad836b1-0b01-4b4a-ba36-9ded54ebaa85" },
                    { 1, "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb" },
                    { 2, "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb" },
                    { 3, "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb" },
                    { 4, "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb" },
                    { 5, "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb" },
                    { 1, "0f1fa492-6a74-4b89-bde7-0f8d73d66277" },
                    { 2, "0f1fa492-6a74-4b89-bde7-0f8d73d66277" },
                    { 3, "0f1fa492-6a74-4b89-bde7-0f8d73d66277" },
                    { 5, "0f1fa492-6a74-4b89-bde7-0f8d73d66277" },
                    { 1, "20f84ff4-662d-4f0a-bc66-e9170c215a2a" },
                    { 2, "20f84ff4-662d-4f0a-bc66-e9170c215a2a" },
                    { 3, "20f84ff4-662d-4f0a-bc66-e9170c215a2a" },
                    { 4, "20f84ff4-662d-4f0a-bc66-e9170c215a2a" },
                    { 5, "20f84ff4-662d-4f0a-bc66-e9170c215a2a" },
                    { 1, "256a3217-f445-436e-b763-26829df121c6" },
                    { 2, "256a3217-f445-436e-b763-26829df121c6" },
                    { 3, "256a3217-f445-436e-b763-26829df121c6" },
                    { 5, "256a3217-f445-436e-b763-26829df121c6" },
                    { 1, "2a63b060-acc5-41ad-844d-31209d33fa10" },
                    { 2, "2a63b060-acc5-41ad-844d-31209d33fa10" },
                    { 3, "2a63b060-acc5-41ad-844d-31209d33fa10" },
                    { 5, "2a63b060-acc5-41ad-844d-31209d33fa10" },
                    { 2, "2f723a91-bc11-4104-bb01-6d4ebbc60fc5" },
                    { 5, "2f723a91-bc11-4104-bb01-6d4ebbc60fc5" },
                    { 1, "33458ae4-b21f-4c39-8dff-44e87844a6a2" },
                    { 2, "33458ae4-b21f-4c39-8dff-44e87844a6a2" },
                    { 3, "33458ae4-b21f-4c39-8dff-44e87844a6a2" },
                    { 4, "33458ae4-b21f-4c39-8dff-44e87844a6a2" },
                    { 5, "33458ae4-b21f-4c39-8dff-44e87844a6a2" },
                    { 2, "392ff29a-68b8-4c7c-81d6-a5deb6d5a0c2" },
                    { 2, "4762b0c6-1d7f-468a-b4a9-a71d8b1c20f2" },
                    { 1, "4e3b02ca-c436-4827-bc1d-6a283ba44a54" },
                    { 1, "53d5a668-8b04-45d3-be64-60e8ae439894" },
                    { 1, "55fc746a-0a85-4923-a3ce-7a8beb914370" },
                    { 5, "55fc746a-0a85-4923-a3ce-7a8beb914370" },
                    { 1, "58fbb498-4393-41d2-a0e7-d0c364a36cc5" },
                    { 2, "58fbb498-4393-41d2-a0e7-d0c364a36cc5" },
                    { 5, "58fbb498-4393-41d2-a0e7-d0c364a36cc5" },
                    { 2, "5bb1a785-d1f7-4c2d-9da5-cf456df1bfaa" },
                    { 2, "5e27ab2b-8ed1-4f3b-87bd-cc52394088b4" }
                });

            migrationBuilder.InsertData(
                table: "CategoryIngredients",
                columns: new[] { "CategoryId", "IngredientId" },
                values: new object[,]
                {
                    { 1, "68f92dc1-85aa-4876-b86a-8ed4313deaae" },
                    { 1, "6d1898d5-e4e5-4c4e-aed5-a9208b1ccf2b" },
                    { 2, "71a2378d-74de-4c9a-a64b-237820a5b6b9" },
                    { 1, "813bde29-b392-4c16-9a3f-65734d667b08" },
                    { 2, "813bde29-b392-4c16-9a3f-65734d667b08" },
                    { 5, "813bde29-b392-4c16-9a3f-65734d667b08" },
                    { 1, "84def27a-0f81-4532-9907-1645aa7ee027" },
                    { 5, "84def27a-0f81-4532-9907-1645aa7ee027" },
                    { 2, "8b596d55-2f13-45c0-80e3-b023434a14df" },
                    { 2, "8eb5383e-2440-4075-8aab-a774351a6153" },
                    { 5, "8eb5383e-2440-4075-8aab-a774351a6153" },
                    { 2, "9ad3222f-77f7-4d4e-b9a3-66030e993e67" },
                    { 2, "a3b2844c-a654-40cd-8045-e93d89826173" },
                    { 2, "b372fe32-ee80-4d63-9019-9e9d9c87cd99" },
                    { 1, "b48f7dc6-4077-4bfb-8ed4-8f4e8d616908" },
                    { 2, "b48f7dc6-4077-4bfb-8ed4-8f4e8d616908" },
                    { 3, "b48f7dc6-4077-4bfb-8ed4-8f4e8d616908" },
                    { 5, "b48f7dc6-4077-4bfb-8ed4-8f4e8d616908" },
                    { 2, "b8ae6779-3469-4669-89f2-932b49d46fdc" },
                    { 4, "b8ae6779-3469-4669-89f2-932b49d46fdc" },
                    { 2, "bb1979e9-4c7b-412c-9e84-4598bfa0524e" },
                    { 5, "bb1979e9-4c7b-412c-9e84-4598bfa0524e" },
                    { 2, "c20d21eb-326f-4011-b8ba-058399d972c6" },
                    { 3, "c751debf-36b1-4801-af56-8c9096f34309" },
                    { 4, "c751debf-36b1-4801-af56-8c9096f34309" },
                    { 1, "d9979ac9-3401-4257-aded-cc37edd3becb" },
                    { 2, "d9979ac9-3401-4257-aded-cc37edd3becb" },
                    { 3, "d9979ac9-3401-4257-aded-cc37edd3becb" },
                    { 5, "d9979ac9-3401-4257-aded-cc37edd3becb" },
                    { 1, "e4726844-83be-4631-8adb-b4e0ed0e4145" },
                    { 2, "e4726844-83be-4631-8adb-b4e0ed0e4145" },
                    { 3, "e4726844-83be-4631-8adb-b4e0ed0e4145" },
                    { 5, "e4726844-83be-4631-8adb-b4e0ed0e4145" },
                    { 1, "e7791135-4cd6-4c94-afe9-1867dc19c338" },
                    { 2, "e7791135-4cd6-4c94-afe9-1867dc19c338" },
                    { 3, "e7791135-4cd6-4c94-afe9-1867dc19c338" },
                    { 4, "e7791135-4cd6-4c94-afe9-1867dc19c338" },
                    { 2, "e9bf191c-3475-4240-885c-19daba91ca80" },
                    { 2, "e9fbd357-86b4-4f6d-9368-c6434b7a318f" },
                    { 1, "f6903024-2ae3-403e-b7f4-a5cf074e4af7" },
                    { 2, "f6903024-2ae3-403e-b7f4-a5cf074e4af7" },
                    { 3, "f6903024-2ae3-403e-b7f4-a5cf074e4af7" }
                });

            migrationBuilder.InsertData(
                table: "CategoryIngredients",
                columns: new[] { "CategoryId", "IngredientId" },
                values: new object[,]
                {
                    { 5, "f6903024-2ae3-403e-b7f4-a5cf074e4af7" },
                    { 1, "f6dec5d8-15c5-4074-afa9-0b218f18a5f3" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Image", "Name", "Price", "WeightInGrams" },
                values: new object[,]
                {
                    { "0cac471e-e654-4afc-bbde-bd2134be8ede", 1, "https://www.oliveandmango.com/images/uploads/2021_06_21_classic_grilled_cheeseburger_1.jpg", "Cheese With Meatball", 5m, 320 },
                    { "272970b2-99e5-489e-862f-0a40115b888d", 1, "https://flaevor.com/wp-content/uploads/2020/09/SambalFriedChickenBurgerRecipe.jpg", "Breaded Chicken", 4.50m, 300 },
                    { "576ac9e8-633f-4693-9a18-d9f88f939560", 3, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/slow-cooker-lamb-kebab-1584109373.jpg", "Middle Pork Doner", 4m, 300 },
                    { "6076b0f5-75d1-4e24-85be-1a3cf3654e61", 2, "https://www.happyfoodstube.com/wp-content/uploads/2016/03/calzone-pizza-recipe.jpg", "Calzone", 10.50m, 500 },
                    { "60b297c4-61f1-4992-8952-d09759dff272", 3, "https://www.recipetineats.com/wp-content/uploads/2017/11/Chicken-Doner-Kebab-1-SQ.jpg", "Middle Chicken Doner", 4m, 300 },
                    { "64920379-597e-4bad-bd45-e2d2b5b7ada0", 5, "https://www.thespruceeats.com/thmb/jJqSQhrXRmVbPeihyHS-JNy5DCk=/3465x2599/smart/filters:no_upscale()/croque-monsieur-classic-french-grilled-cheese-996061-hero-01-cbf77c357af042fa89080019757916f0.jpg", "Ham And Cheese", 3m, 200 },
                    { "84cbe7b0-01cf-472d-9745-509d00ca9b72", 2, "https://myfoodbook.com.au/sites/default/files/styles/schema_img/public/recipe_photo/pepperoni-pizza.jpg", "Pepperoni", 9.40m, 400 },
                    { "87c6bea9-31f0-4d82-94f8-4cd522b6c90f", 3, "https://www.recipetineats.com/wp-content/uploads/2017/11/Chicken-Doner-Kebab-1-SQ.jpg", "Big Chicken Doner", 5m, 400 },
                    { "88f9cd46-13dc-4033-8a57-151d09f24c8f", 2, "https://www.jocooks.com/wp-content/uploads/2012/03/margherita-pizza-11.jpg", "Margherita", 8.20m, 400 },
                    { "98e94aef-bef9-4cdf-b9db-ad946ad7a9b9", 3, "https://www.recipetineats.com/wp-content/uploads/2017/11/Chicken-Doner-Kebab-1-SQ.jpg", "Small Chicken Doner", 3m, 200 },
                    { "b758ca67-6daf-46d6-83d1-4d637fd25543", 3, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/slow-cooker-lamb-kebab-1584109373.jpg", "Big Pork Doner", 5m, 400 },
                    { "ce94928c-75eb-402d-a905-9ac43aa78067", 1, "https://embed.widencdn.net/img/beef/tlxkgiiioj/1120x840px/lean-mean-cheeseburgers-horizotnal.tif?keep=c&u=7fueml", "Beef", 5m, 350 },
                    { "d7860f6f-6d66-495c-b84c-dae0a7c3c00c", 4, "https://img.taste.com.au/xNrBHHXt/taste/2016/11/chicken-and-vegetable-risotto-76118-1.jpeg", "Rissoto With Vegetables", 3.50m, 300 },
                    { "f4bfdd80-22cb-44c6-a416-b370dc471e21", 4, "https://embed.widencdn.net/img/beef/xsoogkvab0/1120x840px/slow-cooked-beef-risotto.eps?keep=c&u=7fueml", "Rissoto With Meat", 4.50m, 300 },
                    { "f969642a-bc37-4107-871d-c5ce4d10b163", 3, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/slow-cooker-lamb-kebab-1584109373.jpg", "Small Pork Doner", 3m, 200 }
                });

            migrationBuilder.InsertData(
                table: "ProductIngredient",
                columns: new[] { "IngredientId", "ProductId" },
                values: new object[,]
                {
                    { "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb", "0cac471e-e654-4afc-bbde-bd2134be8ede" },
                    { "20f84ff4-662d-4f0a-bc66-e9170c215a2a", "0cac471e-e654-4afc-bbde-bd2134be8ede" },
                    { "2a63b060-acc5-41ad-844d-31209d33fa10", "0cac471e-e654-4afc-bbde-bd2134be8ede" },
                    { "53d5a668-8b04-45d3-be64-60e8ae439894", "0cac471e-e654-4afc-bbde-bd2134be8ede" },
                    { "58fbb498-4393-41d2-a0e7-d0c364a36cc5", "0cac471e-e654-4afc-bbde-bd2134be8ede" },
                    { "813bde29-b392-4c16-9a3f-65734d667b08", "0cac471e-e654-4afc-bbde-bd2134be8ede" },
                    { "f6903024-2ae3-403e-b7f4-a5cf074e4af7", "0cac471e-e654-4afc-bbde-bd2134be8ede" },
                    { "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb", "272970b2-99e5-489e-862f-0a40115b888d" },
                    { "20f84ff4-662d-4f0a-bc66-e9170c215a2a", "272970b2-99e5-489e-862f-0a40115b888d" },
                    { "2a63b060-acc5-41ad-844d-31209d33fa10", "272970b2-99e5-489e-862f-0a40115b888d" },
                    { "4e3b02ca-c436-4827-bc1d-6a283ba44a54", "272970b2-99e5-489e-862f-0a40115b888d" },
                    { "813bde29-b392-4c16-9a3f-65734d667b08", "272970b2-99e5-489e-862f-0a40115b888d" },
                    { "f6903024-2ae3-403e-b7f4-a5cf074e4af7", "272970b2-99e5-489e-862f-0a40115b888d" },
                    { "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb", "576ac9e8-633f-4693-9a18-d9f88f939560" },
                    { "20f84ff4-662d-4f0a-bc66-e9170c215a2a", "576ac9e8-633f-4693-9a18-d9f88f939560" },
                    { "2a63b060-acc5-41ad-844d-31209d33fa10", "576ac9e8-633f-4693-9a18-d9f88f939560" },
                    { "33458ae4-b21f-4c39-8dff-44e87844a6a2", "576ac9e8-633f-4693-9a18-d9f88f939560" },
                    { "b48f7dc6-4077-4bfb-8ed4-8f4e8d616908", "576ac9e8-633f-4693-9a18-d9f88f939560" },
                    { "c751debf-36b1-4801-af56-8c9096f34309", "576ac9e8-633f-4693-9a18-d9f88f939560" },
                    { "d9979ac9-3401-4257-aded-cc37edd3becb", "576ac9e8-633f-4693-9a18-d9f88f939560" },
                    { "0ad836b1-0b01-4b4a-ba36-9ded54ebaa85", "6076b0f5-75d1-4e24-85be-1a3cf3654e61" },
                    { "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb", "6076b0f5-75d1-4e24-85be-1a3cf3654e61" },
                    { "392ff29a-68b8-4c7c-81d6-a5deb6d5a0c2", "6076b0f5-75d1-4e24-85be-1a3cf3654e61" },
                    { "5e27ab2b-8ed1-4f3b-87bd-cc52394088b4", "6076b0f5-75d1-4e24-85be-1a3cf3654e61" },
                    { "9ad3222f-77f7-4d4e-b9a3-66030e993e67", "6076b0f5-75d1-4e24-85be-1a3cf3654e61" },
                    { "bb1979e9-4c7b-412c-9e84-4598bfa0524e", "6076b0f5-75d1-4e24-85be-1a3cf3654e61" },
                    { "c20d21eb-326f-4011-b8ba-058399d972c6", "6076b0f5-75d1-4e24-85be-1a3cf3654e61" },
                    { "e9bf191c-3475-4240-885c-19daba91ca80", "6076b0f5-75d1-4e24-85be-1a3cf3654e61" },
                    { "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb", "60b297c4-61f1-4992-8952-d09759dff272" },
                    { "20f84ff4-662d-4f0a-bc66-e9170c215a2a", "60b297c4-61f1-4992-8952-d09759dff272" },
                    { "2a63b060-acc5-41ad-844d-31209d33fa10", "60b297c4-61f1-4992-8952-d09759dff272" },
                    { "33458ae4-b21f-4c39-8dff-44e87844a6a2", "60b297c4-61f1-4992-8952-d09759dff272" },
                    { "b48f7dc6-4077-4bfb-8ed4-8f4e8d616908", "60b297c4-61f1-4992-8952-d09759dff272" },
                    { "d9979ac9-3401-4257-aded-cc37edd3becb", "60b297c4-61f1-4992-8952-d09759dff272" },
                    { "e7791135-4cd6-4c94-afe9-1867dc19c338", "60b297c4-61f1-4992-8952-d09759dff272" },
                    { "20f84ff4-662d-4f0a-bc66-e9170c215a2a", "64920379-597e-4bad-bd45-e2d2b5b7ada0" },
                    { "2a63b060-acc5-41ad-844d-31209d33fa10", "64920379-597e-4bad-bd45-e2d2b5b7ada0" },
                    { "2f723a91-bc11-4104-bb01-6d4ebbc60fc5", "64920379-597e-4bad-bd45-e2d2b5b7ada0" },
                    { "58fbb498-4393-41d2-a0e7-d0c364a36cc5", "64920379-597e-4bad-bd45-e2d2b5b7ada0" },
                    { "0ad836b1-0b01-4b4a-ba36-9ded54ebaa85", "84cbe7b0-01cf-472d-9745-509d00ca9b72" },
                    { "5e27ab2b-8ed1-4f3b-87bd-cc52394088b4", "84cbe7b0-01cf-472d-9745-509d00ca9b72" },
                    { "c20d21eb-326f-4011-b8ba-058399d972c6", "84cbe7b0-01cf-472d-9745-509d00ca9b72" }
                });

            migrationBuilder.InsertData(
                table: "ProductIngredient",
                columns: new[] { "IngredientId", "ProductId" },
                values: new object[,]
                {
                    { "e9bf191c-3475-4240-885c-19daba91ca80", "84cbe7b0-01cf-472d-9745-509d00ca9b72" },
                    { "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb", "87c6bea9-31f0-4d82-94f8-4cd522b6c90f" },
                    { "20f84ff4-662d-4f0a-bc66-e9170c215a2a", "87c6bea9-31f0-4d82-94f8-4cd522b6c90f" },
                    { "2a63b060-acc5-41ad-844d-31209d33fa10", "87c6bea9-31f0-4d82-94f8-4cd522b6c90f" },
                    { "33458ae4-b21f-4c39-8dff-44e87844a6a2", "87c6bea9-31f0-4d82-94f8-4cd522b6c90f" },
                    { "b48f7dc6-4077-4bfb-8ed4-8f4e8d616908", "87c6bea9-31f0-4d82-94f8-4cd522b6c90f" },
                    { "d9979ac9-3401-4257-aded-cc37edd3becb", "87c6bea9-31f0-4d82-94f8-4cd522b6c90f" },
                    { "e7791135-4cd6-4c94-afe9-1867dc19c338", "87c6bea9-31f0-4d82-94f8-4cd522b6c90f" },
                    { "0ad836b1-0b01-4b4a-ba36-9ded54ebaa85", "88f9cd46-13dc-4033-8a57-151d09f24c8f" },
                    { "5e27ab2b-8ed1-4f3b-87bd-cc52394088b4", "88f9cd46-13dc-4033-8a57-151d09f24c8f" },
                    { "a3b2844c-a654-40cd-8045-e93d89826173", "88f9cd46-13dc-4033-8a57-151d09f24c8f" },
                    { "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb", "98e94aef-bef9-4cdf-b9db-ad946ad7a9b9" },
                    { "20f84ff4-662d-4f0a-bc66-e9170c215a2a", "98e94aef-bef9-4cdf-b9db-ad946ad7a9b9" },
                    { "2a63b060-acc5-41ad-844d-31209d33fa10", "98e94aef-bef9-4cdf-b9db-ad946ad7a9b9" },
                    { "33458ae4-b21f-4c39-8dff-44e87844a6a2", "98e94aef-bef9-4cdf-b9db-ad946ad7a9b9" },
                    { "b48f7dc6-4077-4bfb-8ed4-8f4e8d616908", "98e94aef-bef9-4cdf-b9db-ad946ad7a9b9" },
                    { "d9979ac9-3401-4257-aded-cc37edd3becb", "98e94aef-bef9-4cdf-b9db-ad946ad7a9b9" },
                    { "e7791135-4cd6-4c94-afe9-1867dc19c338", "98e94aef-bef9-4cdf-b9db-ad946ad7a9b9" },
                    { "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb", "b758ca67-6daf-46d6-83d1-4d637fd25543" },
                    { "20f84ff4-662d-4f0a-bc66-e9170c215a2a", "b758ca67-6daf-46d6-83d1-4d637fd25543" },
                    { "2a63b060-acc5-41ad-844d-31209d33fa10", "b758ca67-6daf-46d6-83d1-4d637fd25543" },
                    { "33458ae4-b21f-4c39-8dff-44e87844a6a2", "b758ca67-6daf-46d6-83d1-4d637fd25543" },
                    { "b48f7dc6-4077-4bfb-8ed4-8f4e8d616908", "b758ca67-6daf-46d6-83d1-4d637fd25543" },
                    { "c751debf-36b1-4801-af56-8c9096f34309", "b758ca67-6daf-46d6-83d1-4d637fd25543" },
                    { "d9979ac9-3401-4257-aded-cc37edd3becb", "b758ca67-6daf-46d6-83d1-4d637fd25543" },
                    { "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb", "ce94928c-75eb-402d-a905-9ac43aa78067" },
                    { "20f84ff4-662d-4f0a-bc66-e9170c215a2a", "ce94928c-75eb-402d-a905-9ac43aa78067" },
                    { "2a63b060-acc5-41ad-844d-31209d33fa10", "ce94928c-75eb-402d-a905-9ac43aa78067" },
                    { "813bde29-b392-4c16-9a3f-65734d667b08", "ce94928c-75eb-402d-a905-9ac43aa78067" },
                    { "f6903024-2ae3-403e-b7f4-a5cf074e4af7", "ce94928c-75eb-402d-a905-9ac43aa78067" },
                    { "f6dec5d8-15c5-4074-afa9-0b218f18a5f3", "ce94928c-75eb-402d-a905-9ac43aa78067" },
                    { "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb", "d7860f6f-6d66-495c-b84c-dae0a7c3c00c" },
                    { "20f84ff4-662d-4f0a-bc66-e9170c215a2a", "d7860f6f-6d66-495c-b84c-dae0a7c3c00c" },
                    { "2a63b060-acc5-41ad-844d-31209d33fa10", "d7860f6f-6d66-495c-b84c-dae0a7c3c00c" },
                    { "b8ae6779-3469-4669-89f2-932b49d46fdc", "d7860f6f-6d66-495c-b84c-dae0a7c3c00c" },
                    { "e7791135-4cd6-4c94-afe9-1867dc19c338", "f4bfdd80-22cb-44c6-a416-b370dc471e21" },
                    { "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb", "f969642a-bc37-4107-871d-c5ce4d10b163" },
                    { "20f84ff4-662d-4f0a-bc66-e9170c215a2a", "f969642a-bc37-4107-871d-c5ce4d10b163" },
                    { "2a63b060-acc5-41ad-844d-31209d33fa10", "f969642a-bc37-4107-871d-c5ce4d10b163" },
                    { "33458ae4-b21f-4c39-8dff-44e87844a6a2", "f969642a-bc37-4107-871d-c5ce4d10b163" },
                    { "b48f7dc6-4077-4bfb-8ed4-8f4e8d616908", "f969642a-bc37-4107-871d-c5ce4d10b163" },
                    { "c751debf-36b1-4801-af56-8c9096f34309", "f969642a-bc37-4107-871d-c5ce4d10b163" }
                });

            migrationBuilder.InsertData(
                table: "ProductIngredient",
                columns: new[] { "IngredientId", "ProductId" },
                values: new object[] { "d9979ac9-3401-4257-aded-cc37edd3becb", "f969642a-bc37-4107-871d-c5ce4d10b163" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "df578c9e-41dc-48e6-b352-5f4f33577c63");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8881f953-e7cc-4d0d-8937-9a74413e60c5", "bcc9e639-b998-466b-8d67-5e7dda1dfe5a" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 1, "0ad836b1-0b01-4b4a-ba36-9ded54ebaa85" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 1, "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 3, "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 4, "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 5, "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 1, "0f1fa492-6a74-4b89-bde7-0f8d73d66277" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "0f1fa492-6a74-4b89-bde7-0f8d73d66277" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 3, "0f1fa492-6a74-4b89-bde7-0f8d73d66277" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 5, "0f1fa492-6a74-4b89-bde7-0f8d73d66277" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 1, "20f84ff4-662d-4f0a-bc66-e9170c215a2a" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "20f84ff4-662d-4f0a-bc66-e9170c215a2a" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 3, "20f84ff4-662d-4f0a-bc66-e9170c215a2a" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 4, "20f84ff4-662d-4f0a-bc66-e9170c215a2a" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 5, "20f84ff4-662d-4f0a-bc66-e9170c215a2a" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 1, "256a3217-f445-436e-b763-26829df121c6" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "256a3217-f445-436e-b763-26829df121c6" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 3, "256a3217-f445-436e-b763-26829df121c6" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 5, "256a3217-f445-436e-b763-26829df121c6" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 1, "2a63b060-acc5-41ad-844d-31209d33fa10" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "2a63b060-acc5-41ad-844d-31209d33fa10" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 3, "2a63b060-acc5-41ad-844d-31209d33fa10" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 5, "2a63b060-acc5-41ad-844d-31209d33fa10" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "2f723a91-bc11-4104-bb01-6d4ebbc60fc5" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 5, "2f723a91-bc11-4104-bb01-6d4ebbc60fc5" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 1, "33458ae4-b21f-4c39-8dff-44e87844a6a2" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "33458ae4-b21f-4c39-8dff-44e87844a6a2" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 3, "33458ae4-b21f-4c39-8dff-44e87844a6a2" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 4, "33458ae4-b21f-4c39-8dff-44e87844a6a2" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 5, "33458ae4-b21f-4c39-8dff-44e87844a6a2" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "392ff29a-68b8-4c7c-81d6-a5deb6d5a0c2" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "4762b0c6-1d7f-468a-b4a9-a71d8b1c20f2" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 1, "4e3b02ca-c436-4827-bc1d-6a283ba44a54" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 1, "53d5a668-8b04-45d3-be64-60e8ae439894" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 1, "55fc746a-0a85-4923-a3ce-7a8beb914370" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 5, "55fc746a-0a85-4923-a3ce-7a8beb914370" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 1, "58fbb498-4393-41d2-a0e7-d0c364a36cc5" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "58fbb498-4393-41d2-a0e7-d0c364a36cc5" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 5, "58fbb498-4393-41d2-a0e7-d0c364a36cc5" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "5bb1a785-d1f7-4c2d-9da5-cf456df1bfaa" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "5e27ab2b-8ed1-4f3b-87bd-cc52394088b4" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 1, "68f92dc1-85aa-4876-b86a-8ed4313deaae" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 1, "6d1898d5-e4e5-4c4e-aed5-a9208b1ccf2b" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "71a2378d-74de-4c9a-a64b-237820a5b6b9" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 1, "813bde29-b392-4c16-9a3f-65734d667b08" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "813bde29-b392-4c16-9a3f-65734d667b08" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 5, "813bde29-b392-4c16-9a3f-65734d667b08" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 1, "84def27a-0f81-4532-9907-1645aa7ee027" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 5, "84def27a-0f81-4532-9907-1645aa7ee027" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "8b596d55-2f13-45c0-80e3-b023434a14df" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "8eb5383e-2440-4075-8aab-a774351a6153" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 5, "8eb5383e-2440-4075-8aab-a774351a6153" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "9ad3222f-77f7-4d4e-b9a3-66030e993e67" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "a3b2844c-a654-40cd-8045-e93d89826173" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "b372fe32-ee80-4d63-9019-9e9d9c87cd99" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 1, "b48f7dc6-4077-4bfb-8ed4-8f4e8d616908" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "b48f7dc6-4077-4bfb-8ed4-8f4e8d616908" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 3, "b48f7dc6-4077-4bfb-8ed4-8f4e8d616908" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 5, "b48f7dc6-4077-4bfb-8ed4-8f4e8d616908" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "b8ae6779-3469-4669-89f2-932b49d46fdc" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 4, "b8ae6779-3469-4669-89f2-932b49d46fdc" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "bb1979e9-4c7b-412c-9e84-4598bfa0524e" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 5, "bb1979e9-4c7b-412c-9e84-4598bfa0524e" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "c20d21eb-326f-4011-b8ba-058399d972c6" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 3, "c751debf-36b1-4801-af56-8c9096f34309" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 4, "c751debf-36b1-4801-af56-8c9096f34309" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 1, "d9979ac9-3401-4257-aded-cc37edd3becb" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "d9979ac9-3401-4257-aded-cc37edd3becb" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 3, "d9979ac9-3401-4257-aded-cc37edd3becb" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 5, "d9979ac9-3401-4257-aded-cc37edd3becb" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 1, "e4726844-83be-4631-8adb-b4e0ed0e4145" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "e4726844-83be-4631-8adb-b4e0ed0e4145" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 3, "e4726844-83be-4631-8adb-b4e0ed0e4145" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 5, "e4726844-83be-4631-8adb-b4e0ed0e4145" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 1, "e7791135-4cd6-4c94-afe9-1867dc19c338" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "e7791135-4cd6-4c94-afe9-1867dc19c338" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 3, "e7791135-4cd6-4c94-afe9-1867dc19c338" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 4, "e7791135-4cd6-4c94-afe9-1867dc19c338" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "e9bf191c-3475-4240-885c-19daba91ca80" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "e9fbd357-86b4-4f6d-9368-c6434b7a318f" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 1, "f6903024-2ae3-403e-b7f4-a5cf074e4af7" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 2, "f6903024-2ae3-403e-b7f4-a5cf074e4af7" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 3, "f6903024-2ae3-403e-b7f4-a5cf074e4af7" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 5, "f6903024-2ae3-403e-b7f4-a5cf074e4af7" });

            migrationBuilder.DeleteData(
                table: "CategoryIngredients",
                keyColumns: new[] { "CategoryId", "IngredientId" },
                keyValues: new object[] { 1, "f6dec5d8-15c5-4074-afa9-0b218f18a5f3" });

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "b1b16da7-738b-4211-a5e2-b8f6f62cd986");

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb", "0cac471e-e654-4afc-bbde-bd2134be8ede" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "20f84ff4-662d-4f0a-bc66-e9170c215a2a", "0cac471e-e654-4afc-bbde-bd2134be8ede" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "2a63b060-acc5-41ad-844d-31209d33fa10", "0cac471e-e654-4afc-bbde-bd2134be8ede" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "53d5a668-8b04-45d3-be64-60e8ae439894", "0cac471e-e654-4afc-bbde-bd2134be8ede" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "58fbb498-4393-41d2-a0e7-d0c364a36cc5", "0cac471e-e654-4afc-bbde-bd2134be8ede" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "813bde29-b392-4c16-9a3f-65734d667b08", "0cac471e-e654-4afc-bbde-bd2134be8ede" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "f6903024-2ae3-403e-b7f4-a5cf074e4af7", "0cac471e-e654-4afc-bbde-bd2134be8ede" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb", "272970b2-99e5-489e-862f-0a40115b888d" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "20f84ff4-662d-4f0a-bc66-e9170c215a2a", "272970b2-99e5-489e-862f-0a40115b888d" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "2a63b060-acc5-41ad-844d-31209d33fa10", "272970b2-99e5-489e-862f-0a40115b888d" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "4e3b02ca-c436-4827-bc1d-6a283ba44a54", "272970b2-99e5-489e-862f-0a40115b888d" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "813bde29-b392-4c16-9a3f-65734d667b08", "272970b2-99e5-489e-862f-0a40115b888d" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "f6903024-2ae3-403e-b7f4-a5cf074e4af7", "272970b2-99e5-489e-862f-0a40115b888d" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb", "576ac9e8-633f-4693-9a18-d9f88f939560" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "20f84ff4-662d-4f0a-bc66-e9170c215a2a", "576ac9e8-633f-4693-9a18-d9f88f939560" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "2a63b060-acc5-41ad-844d-31209d33fa10", "576ac9e8-633f-4693-9a18-d9f88f939560" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "33458ae4-b21f-4c39-8dff-44e87844a6a2", "576ac9e8-633f-4693-9a18-d9f88f939560" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "b48f7dc6-4077-4bfb-8ed4-8f4e8d616908", "576ac9e8-633f-4693-9a18-d9f88f939560" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "c751debf-36b1-4801-af56-8c9096f34309", "576ac9e8-633f-4693-9a18-d9f88f939560" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "d9979ac9-3401-4257-aded-cc37edd3becb", "576ac9e8-633f-4693-9a18-d9f88f939560" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "0ad836b1-0b01-4b4a-ba36-9ded54ebaa85", "6076b0f5-75d1-4e24-85be-1a3cf3654e61" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb", "6076b0f5-75d1-4e24-85be-1a3cf3654e61" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "392ff29a-68b8-4c7c-81d6-a5deb6d5a0c2", "6076b0f5-75d1-4e24-85be-1a3cf3654e61" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "5e27ab2b-8ed1-4f3b-87bd-cc52394088b4", "6076b0f5-75d1-4e24-85be-1a3cf3654e61" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "9ad3222f-77f7-4d4e-b9a3-66030e993e67", "6076b0f5-75d1-4e24-85be-1a3cf3654e61" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "bb1979e9-4c7b-412c-9e84-4598bfa0524e", "6076b0f5-75d1-4e24-85be-1a3cf3654e61" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "c20d21eb-326f-4011-b8ba-058399d972c6", "6076b0f5-75d1-4e24-85be-1a3cf3654e61" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "e9bf191c-3475-4240-885c-19daba91ca80", "6076b0f5-75d1-4e24-85be-1a3cf3654e61" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb", "60b297c4-61f1-4992-8952-d09759dff272" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "20f84ff4-662d-4f0a-bc66-e9170c215a2a", "60b297c4-61f1-4992-8952-d09759dff272" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "2a63b060-acc5-41ad-844d-31209d33fa10", "60b297c4-61f1-4992-8952-d09759dff272" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "33458ae4-b21f-4c39-8dff-44e87844a6a2", "60b297c4-61f1-4992-8952-d09759dff272" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "b48f7dc6-4077-4bfb-8ed4-8f4e8d616908", "60b297c4-61f1-4992-8952-d09759dff272" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "d9979ac9-3401-4257-aded-cc37edd3becb", "60b297c4-61f1-4992-8952-d09759dff272" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "e7791135-4cd6-4c94-afe9-1867dc19c338", "60b297c4-61f1-4992-8952-d09759dff272" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "20f84ff4-662d-4f0a-bc66-e9170c215a2a", "64920379-597e-4bad-bd45-e2d2b5b7ada0" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "2a63b060-acc5-41ad-844d-31209d33fa10", "64920379-597e-4bad-bd45-e2d2b5b7ada0" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "2f723a91-bc11-4104-bb01-6d4ebbc60fc5", "64920379-597e-4bad-bd45-e2d2b5b7ada0" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "58fbb498-4393-41d2-a0e7-d0c364a36cc5", "64920379-597e-4bad-bd45-e2d2b5b7ada0" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "0ad836b1-0b01-4b4a-ba36-9ded54ebaa85", "84cbe7b0-01cf-472d-9745-509d00ca9b72" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "5e27ab2b-8ed1-4f3b-87bd-cc52394088b4", "84cbe7b0-01cf-472d-9745-509d00ca9b72" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "c20d21eb-326f-4011-b8ba-058399d972c6", "84cbe7b0-01cf-472d-9745-509d00ca9b72" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "e9bf191c-3475-4240-885c-19daba91ca80", "84cbe7b0-01cf-472d-9745-509d00ca9b72" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb", "87c6bea9-31f0-4d82-94f8-4cd522b6c90f" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "20f84ff4-662d-4f0a-bc66-e9170c215a2a", "87c6bea9-31f0-4d82-94f8-4cd522b6c90f" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "2a63b060-acc5-41ad-844d-31209d33fa10", "87c6bea9-31f0-4d82-94f8-4cd522b6c90f" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "33458ae4-b21f-4c39-8dff-44e87844a6a2", "87c6bea9-31f0-4d82-94f8-4cd522b6c90f" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "b48f7dc6-4077-4bfb-8ed4-8f4e8d616908", "87c6bea9-31f0-4d82-94f8-4cd522b6c90f" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "d9979ac9-3401-4257-aded-cc37edd3becb", "87c6bea9-31f0-4d82-94f8-4cd522b6c90f" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "e7791135-4cd6-4c94-afe9-1867dc19c338", "87c6bea9-31f0-4d82-94f8-4cd522b6c90f" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "0ad836b1-0b01-4b4a-ba36-9ded54ebaa85", "88f9cd46-13dc-4033-8a57-151d09f24c8f" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "5e27ab2b-8ed1-4f3b-87bd-cc52394088b4", "88f9cd46-13dc-4033-8a57-151d09f24c8f" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "a3b2844c-a654-40cd-8045-e93d89826173", "88f9cd46-13dc-4033-8a57-151d09f24c8f" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb", "98e94aef-bef9-4cdf-b9db-ad946ad7a9b9" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "20f84ff4-662d-4f0a-bc66-e9170c215a2a", "98e94aef-bef9-4cdf-b9db-ad946ad7a9b9" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "2a63b060-acc5-41ad-844d-31209d33fa10", "98e94aef-bef9-4cdf-b9db-ad946ad7a9b9" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "33458ae4-b21f-4c39-8dff-44e87844a6a2", "98e94aef-bef9-4cdf-b9db-ad946ad7a9b9" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "b48f7dc6-4077-4bfb-8ed4-8f4e8d616908", "98e94aef-bef9-4cdf-b9db-ad946ad7a9b9" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "d9979ac9-3401-4257-aded-cc37edd3becb", "98e94aef-bef9-4cdf-b9db-ad946ad7a9b9" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "e7791135-4cd6-4c94-afe9-1867dc19c338", "98e94aef-bef9-4cdf-b9db-ad946ad7a9b9" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb", "b758ca67-6daf-46d6-83d1-4d637fd25543" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "20f84ff4-662d-4f0a-bc66-e9170c215a2a", "b758ca67-6daf-46d6-83d1-4d637fd25543" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "2a63b060-acc5-41ad-844d-31209d33fa10", "b758ca67-6daf-46d6-83d1-4d637fd25543" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "33458ae4-b21f-4c39-8dff-44e87844a6a2", "b758ca67-6daf-46d6-83d1-4d637fd25543" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "b48f7dc6-4077-4bfb-8ed4-8f4e8d616908", "b758ca67-6daf-46d6-83d1-4d637fd25543" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "c751debf-36b1-4801-af56-8c9096f34309", "b758ca67-6daf-46d6-83d1-4d637fd25543" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "d9979ac9-3401-4257-aded-cc37edd3becb", "b758ca67-6daf-46d6-83d1-4d637fd25543" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb", "ce94928c-75eb-402d-a905-9ac43aa78067" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "20f84ff4-662d-4f0a-bc66-e9170c215a2a", "ce94928c-75eb-402d-a905-9ac43aa78067" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "2a63b060-acc5-41ad-844d-31209d33fa10", "ce94928c-75eb-402d-a905-9ac43aa78067" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "813bde29-b392-4c16-9a3f-65734d667b08", "ce94928c-75eb-402d-a905-9ac43aa78067" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "f6903024-2ae3-403e-b7f4-a5cf074e4af7", "ce94928c-75eb-402d-a905-9ac43aa78067" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "f6dec5d8-15c5-4074-afa9-0b218f18a5f3", "ce94928c-75eb-402d-a905-9ac43aa78067" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb", "d7860f6f-6d66-495c-b84c-dae0a7c3c00c" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "20f84ff4-662d-4f0a-bc66-e9170c215a2a", "d7860f6f-6d66-495c-b84c-dae0a7c3c00c" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "2a63b060-acc5-41ad-844d-31209d33fa10", "d7860f6f-6d66-495c-b84c-dae0a7c3c00c" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "b8ae6779-3469-4669-89f2-932b49d46fdc", "d7860f6f-6d66-495c-b84c-dae0a7c3c00c" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "e7791135-4cd6-4c94-afe9-1867dc19c338", "f4bfdd80-22cb-44c6-a416-b370dc471e21" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb", "f969642a-bc37-4107-871d-c5ce4d10b163" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "20f84ff4-662d-4f0a-bc66-e9170c215a2a", "f969642a-bc37-4107-871d-c5ce4d10b163" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "2a63b060-acc5-41ad-844d-31209d33fa10", "f969642a-bc37-4107-871d-c5ce4d10b163" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "33458ae4-b21f-4c39-8dff-44e87844a6a2", "f969642a-bc37-4107-871d-c5ce4d10b163" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "b48f7dc6-4077-4bfb-8ed4-8f4e8d616908", "f969642a-bc37-4107-871d-c5ce4d10b163" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "c751debf-36b1-4801-af56-8c9096f34309", "f969642a-bc37-4107-871d-c5ce4d10b163" });

            migrationBuilder.DeleteData(
                table: "ProductIngredient",
                keyColumns: new[] { "IngredientId", "ProductId" },
                keyValues: new object[] { "d9979ac9-3401-4257-aded-cc37edd3becb", "f969642a-bc37-4107-871d-c5ce4d10b163" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8881f953-e7cc-4d0d-8937-9a74413e60c5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bcc9e639-b998-466b-8d67-5e7dda1dfe5a");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "0ad836b1-0b01-4b4a-ba36-9ded54ebaa85");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "0b11bbb6-0d3d-4233-8f94-c6e11f9682fb");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "0f1fa492-6a74-4b89-bde7-0f8d73d66277");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "20f84ff4-662d-4f0a-bc66-e9170c215a2a");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "256a3217-f445-436e-b763-26829df121c6");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "2a63b060-acc5-41ad-844d-31209d33fa10");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "2f723a91-bc11-4104-bb01-6d4ebbc60fc5");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "33458ae4-b21f-4c39-8dff-44e87844a6a2");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "392ff29a-68b8-4c7c-81d6-a5deb6d5a0c2");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "4762b0c6-1d7f-468a-b4a9-a71d8b1c20f2");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "4e3b02ca-c436-4827-bc1d-6a283ba44a54");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "53d5a668-8b04-45d3-be64-60e8ae439894");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "55fc746a-0a85-4923-a3ce-7a8beb914370");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "58fbb498-4393-41d2-a0e7-d0c364a36cc5");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "5bb1a785-d1f7-4c2d-9da5-cf456df1bfaa");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "5e27ab2b-8ed1-4f3b-87bd-cc52394088b4");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "68f92dc1-85aa-4876-b86a-8ed4313deaae");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "6d1898d5-e4e5-4c4e-aed5-a9208b1ccf2b");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "71a2378d-74de-4c9a-a64b-237820a5b6b9");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "813bde29-b392-4c16-9a3f-65734d667b08");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "84def27a-0f81-4532-9907-1645aa7ee027");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "8b596d55-2f13-45c0-80e3-b023434a14df");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "8eb5383e-2440-4075-8aab-a774351a6153");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "9ad3222f-77f7-4d4e-b9a3-66030e993e67");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "a3b2844c-a654-40cd-8045-e93d89826173");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "b372fe32-ee80-4d63-9019-9e9d9c87cd99");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "b48f7dc6-4077-4bfb-8ed4-8f4e8d616908");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "b8ae6779-3469-4669-89f2-932b49d46fdc");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "bb1979e9-4c7b-412c-9e84-4598bfa0524e");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "c20d21eb-326f-4011-b8ba-058399d972c6");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "c751debf-36b1-4801-af56-8c9096f34309");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "d9979ac9-3401-4257-aded-cc37edd3becb");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "e4726844-83be-4631-8adb-b4e0ed0e4145");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "e7791135-4cd6-4c94-afe9-1867dc19c338");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "e9bf191c-3475-4240-885c-19daba91ca80");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "e9fbd357-86b4-4f6d-9368-c6434b7a318f");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "f6903024-2ae3-403e-b7f4-a5cf074e4af7");

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: "f6dec5d8-15c5-4074-afa9-0b218f18a5f3");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "0cac471e-e654-4afc-bbde-bd2134be8ede");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "272970b2-99e5-489e-862f-0a40115b888d");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "576ac9e8-633f-4693-9a18-d9f88f939560");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "6076b0f5-75d1-4e24-85be-1a3cf3654e61");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "60b297c4-61f1-4992-8952-d09759dff272");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "64920379-597e-4bad-bd45-e2d2b5b7ada0");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "84cbe7b0-01cf-472d-9745-509d00ca9b72");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "87c6bea9-31f0-4d82-94f8-4cd522b6c90f");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "88f9cd46-13dc-4033-8a57-151d09f24c8f");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "98e94aef-bef9-4cdf-b9db-ad946ad7a9b9");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "b758ca67-6daf-46d6-83d1-4d637fd25543");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "ce94928c-75eb-402d-a905-9ac43aa78067");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "d7860f6f-6d66-495c-b84c-dae0a7c3c00c");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "f4bfdd80-22cb-44c6-a416-b370dc471e21");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "f969642a-bc37-4107-871d-c5ce4d10b163");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
