using DNDCatalog.Core.ClassAggregate;
using DNDCatalog.Core.MagicItemAggregate;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DNDCatalog.UnitTests.Data;

internal static class FakeData
{
    public static Class classCleric {get;} = new Class() { Id = Guid.Parse("3d9160f1-238a-4801-a62f-3330ca47c6bd"),Name = "Cleric",Description = "Cleric description"};
    public static Class classWarlock {get;} = new Class() { Id = Guid.Parse("5dbe7987-589c-428d-aaaa-9df776aa1488"),Name = "Warlock",Description = "Warlock description"};
    public static Class classBard {get;} = new Class() { Id = Guid.Parse("430ffa07-bfa6-4df0-bac8-162ef8604c89"),Name = "Bard",Description = "Bard description"};
    public static Class classRogue {get;} = new Class() { Id = Guid.Parse("a54c223b-92c7-48ea-a601-e91ade6cffc5"),Name = "Rogue",Description = "Rogue description"};
    public static Class classMonk {get;} = new Class() { Id = Guid.Parse("a0c83a95-32e4-4b42-9a6b-91f61f75812a"),Name = "Monk",Description = "Monk description"};
    public static Class classDruid {get;} = new Class() { Id = Guid.Parse("ac78f523-3134-4d72-bbeb-80237d9550fc"),Name = "Druid",Description = "Druid description"};
    public static Class classSorcerer {get;} = new Class() { Id = Guid.Parse("be376627-acb5-4c77-a344-5ee391408692"),Name = "Sorcerer",Description = "Sorcerer description"};
    public static Class classRanger {get;} = new Class() { Id = Guid.Parse("cfdc715c-d181-4f55-aa43-f8a969d086e0"),Name = "Ranger",Description = "Ranger description"};
    public static Class classPaladin {get;} = new Class() { Id = Guid.Parse("f8b63b17-3701-4f8a-8b19-e7f0001528c1"),Name = "Paladin",Description = "Paladin description"};
    public static Class classWizard {get;} = new Class() { Id = Guid.Parse("15008163-303c-452b-9022-577ac8afa70a"),Name = "Wizard",Description = "Wizard description"};
    public static Class classArtificer { get; } = new Class() { Id = Guid.Parse("435b3426-58be-4115-b86c-e9eeeec0b853"), Name = "Artificer", Description = "Artificer description" };


    public static IEnumerable<Class> GetClasses()
    { 
        return new List<Class>(){
            classCleric,
            classWarlock,
            classBard,
            classRogue,
            classMonk,
            classDruid,
            classSorcerer,
            classRanger,
            classPaladin,
            classWizard,
            classArtificer,
        };
    }




	public static MagicItem magicItemAdamantineArmor { get; } = new MagicItem()
	{
		Id = Guid.Parse("B4E23081-1C55-4875-ADF0-BDC4075419D6"),
		NameUa = "",
		DescriptionUa = "",
		Consumable = false,
		Charged = false,
		NameRus = "Адамантиновый доспех",
		NameEng = "Adamantine Armor",
		DescriptionUa1 = "<p> Ця броня підкріплена Адамантином, однією з найбільш довговічних з існуючих речовин.\n Поки ви носите ці броні, всі критичні хіти для вас вважаються звичайними ударами. </p>",
		DescriptionUa2 = "<div itemprop = \"опис\"> <p> Ці броні підкріплені адамантином, однією з найбільш довговічних з існуючих речовин.\n Поки ви носите ці броні, всі критичні удари для вас вважаються звичайними хітами. </p> &#13;\n</div>",
		DescriptionRus1 = "<p>Это доспехи усилены адамантином, одним из самых прочных из существующих веществ. Пока вы носите эти доспехи, все критические попадания по вам считаются обычными попаданиями.</p>",
		DescriptionRus2 = "<div itemprop=\"description\"><p>Эти доспехи усилены адамантином, одним из самых прочных из существующих веществ. Пока вы носите эти доспехи, все критические попадания по вам считаются обычными попаданиями.</p>&#13;\n</div>",
		Source = "«Dungeon master's guide»",
		Attunement = false,
		Type = MagicItemType.Armour,
		Rarity = Rarity.Uncommon,
		Price = new RecomendedPrice() {
			Formula = "(1d6 + 1) * 100",
			MinPrice = 101,
			MaxPrice = 500
		}
	};
	public static MagicItem magicItemAlchemyJugBlue { get; } = new MagicItem()
	{
		Id = Guid.Parse("E41583C9-C49A-4A6E-B875-9D046695F6F8"),
		NameUa = "",
		DescriptionUa = "",
		Consumable = false,
		Charged = false,
		NameRus = "Алхимический сосуд (синий)",
		NameEng = "Alchemy Jug (Blue)",
		DescriptionUa1 = "<p> Цей керамічний глечик, здається, зможе вмістити 1 галон рідини і важить 12 кілограмів, незалежно від того, повна чи порожня.\n Якщо ви струсите його, ви можете почути звуки бризки рідини, навіть якщо глечик порожній. </p> <p> Ви можете зателефонувати одній рідині зі столу нижче, саме тому глечик почне його виробляти.\n Після цього ви все ще можете безперешкодно глечик і вилити цю рідину з судна зі швидкістю до 2 галонів на хвилину.\n Максимальна кількість рідини, яку може виробляти глечик з більш ніж його максимум, до наступного світанку. ; \"> рідина </th> <th style =\" ширина: 105px; текст-вирівнювання: ліворуч; \"> макс.\n том </ple> </tr> </ppead> <tbody> <tr> <td style = \"ширина: 187px;\"> вино </td> <td style = \"ширина: 105px;\"> 1 галлон </ TD> </ TR> <TR> <TD Style = \"Width: 187px;\"> water, fresh </td> <td style = \"width: 105px;\"> 8 gallons </td> </ tr> <tr > <td style = \"ширина: 187px;\"> вода, солона </td> <td style = \"width: 105px;\"> 12 галонів </td> </tr> <td style = \"ширина 187px;\">> \">\"> \">\"> \">\"> \">\"> \">\"> \"> гарячий заварений чай </td> <td style = \"ширина: 105px;\"> 1 чверть </td> </tr> <tr> <td style = \"width: 187px;\"> Майонез </td> <td style = \"Ширина: 105px;\"> 2 галони </td> </tr> <tr> <td style = \"ширина: 187px;\"> олія </td> <td style = \"ширина: 105px;\"> 1 квартал </td> </tr> <tr> <td style = \"ширина: 187px;\" > <Td style = \"width: 187px;\"> пиво </td> <td style = \"width: 105px;\"> 4 галони </td> </tr> <td style = \"Ширина: 187px;\"> оцет 4 : 105px; \"> 1/2 унції </td> </tr> </tbody> </bable>",
		DescriptionUa2 = "<div itemprop = \"опис\"> <p> Цей керамічний глечик, який може вмістити 1 галон рідини і важити 12 кілограмів, незалежно від того, повним чи порожнім.\n Якщо ви струсите його, то ви можете почути звуки бризки рідини, навіть якщо глечик порожній. </p> &#13;\n<p> Ви можете зателефонувати до однієї рідини з таблиці нижче, саме тому глечик почне її виробляти.\n Після цього ви все ще можете безперешкодно глечик і вилити цю рідину з судна зі швидкістю до 2 галонів на хвилину.\n Максимальна кількість рідини, яку може виробляти глечик, залежить від типу рідини, що називається вами. </p> &#13;\n<p> Після того, як глечик починає виробляти вибрану рідину, він не може виробляти іншу або виробляти названу рідину в обсязі більше, ніж її максимум до наступного світанку. </p> &#13;\n<br/> <able> &#13;\n<tbody> &#13;\n<tr class = \"table_head\"> <td> рідина </td> &#13;\n<td> Макс.\n том </td> &#13;\n</tr> &#13;\n<tr> &#13;\n<td> Вино </td> &#13;\n<td> 1 галон </td> &#13;\n</tr> &#13;\n<tr> &#13;\n<td> вода, свіжа </td> &#13;\n<td> 8 галонів </td> &#13;\n</tr> &#13;\n<tr> &#13;\n<td> вода, солона </td> &#13;\n<td> 12 галонів </td> &#13;\n</tr> &#13;\n<tr> &#13;\n<td> гарячий заварений чай </td> &#13;\n<td> 1 квартал </td> &#13;\n</tr> &#13;\n<tr> &#13;\n<td> Майонез </td> &#13;\n<td> 2 галони </td> &#13;\n</tr> &#13;\n<tr> &#13;\n<td> олія </td> &#13;\n<td> 1 квартал </td> &#13;\n</tr> &#13;\n<tr> &#13;\n<td> мед </td> &#13;\n<td> 1 галон </td> &#13;\n</tr> &#13;\n<tr> &#13;\n<td> пиво </td> &#13;\n<td> 4 галони </td> &#13;\n</tr> &#13;\n<tr> &#13;\n<td> оцет </td> &#13;\n<td> 2 галони </td> &#13;\n</tr> &#13;\n</tbody> &#13;\n</able> &#13;\n</div>",
		DescriptionRus1 = "<p>Этот керамический кувшин, кажется способным вместить 1 галлон жидкости и весит 12 фунтов вне зависимости от того, полный он или пустой. Если его потрясти, то можно услышать звуки плескающийся жидкости, даже если кувшин пуст.</p><p>Вы можете действием назвать одну жидкость из приведённой ниже таблицы, отчего кувшин начнёт её производить. После этого вы можете ещё одним действием откупорить кувшин и вылить эту жидкость из сосуда со скоростью до 2 галлонов в минуту. Максимальное количество жидкости, которое может произвести кувшин, зависит от вида жидкости, названной вами.</p><p>После того, как кувшин начинает производить выбранную жидкость, он не может производить другую, или произвести названную жидкость в объёме больше её максимума, пока не наступит следующий рассвет.</p><table class=\"table table-striped table-sm\"><thead><tr><th style=\"width: 187px; text-align: left;\">Жидкость</th><th style=\"width: 105px; text-align: left;\">Макс. объем</th></tr></thead><tbody><tr><td style=\"width: 187px;\">Вино</td><td style=\"width: 105px;\">1 галлон</td></tr><tr><td style=\"width: 187px;\">Вода, пресная</td><td style=\"width: 105px;\">8 галлонов</td></tr><tr><td style=\"width: 187px;\">Вода, солёная</td><td style=\"width: 105px;\">12 галлонов</td></tr><tr><td style=\"width: 187px;\">Горячий заваренный чай</td><td style=\"width: 105px;\">1 кварта</td></tr><tr><td style=\"width: 187px;\">Майонез</td><td style=\"width: 105px;\">2 галлона</td></tr><tr><td style=\"width: 187px;\">Масло</td><td style=\"width: 105px;\">1 кварта</td></tr><tr><td style=\"width: 187px;\">Мёд</td><td style=\"width: 105px;\">1 галлон</td></tr><tr><td style=\"width: 187px;\">Пиво</td><td style=\"width: 105px;\">4 галлона</td></tr><tr><td style=\"width: 187px;\">Уксус</td><td style=\"width: 105px;\">2 галлона</td></tr><tr><td style=\"width: 187px;\">Яд</td><td style=\"width: 105px;\">1/2 унции</td></tr></tbody></table>",
		DescriptionRus2 = "<div itemprop=\"description\"><p>Этот керамический кувшин, кажется способным вместить 1 галлон жидкости и весит 12 фунтов вне зависимости от того, полный он или пустой. Если его потрясти, то можно услышать звуки плескающийся жидкости, даже если кувшин пуст.</p>&#13;\n<p>Вы можете действием назвать одну жидкость из приведённой ниже таблицы, отчего кувшин начнёт её производить. После этого вы можете ещё одним действием откупорить кувшин и вылить эту жидкость из сосуда со скоростью до 2 галлонов в минуту. Максимальное количество жидкости, которое может произвести кувшин, зависит от вида жидкости, названной вами.</p>&#13;\n<p>После того, как кувшин начинает производить выбранную жидкость, он не может производить другую, или произвести названную жидкость в объёме больше её максимума, пока не наступит следующий рассвет.</p>&#13;\n<br/><table>&#13;\n<tbody>&#13;\n<tr class=\"table_header\"><td>Жидкость</td>&#13;\n<td>Макс. объем</td>&#13;\n</tr>&#13;\n<tr>&#13;\n<td>Вино</td>&#13;\n<td>1 галлон</td>&#13;\n</tr>&#13;\n<tr>&#13;\n<td>Вода, пресная</td>&#13;\n<td>8 галлонов</td>&#13;\n</tr>&#13;\n<tr>&#13;\n<td>Вода, солёная</td>&#13;\n<td>12 галлонов</td>&#13;\n</tr>&#13;\n<tr>&#13;\n<td>Горячий заваренный чай</td>&#13;\n<td>1 кварта</td>&#13;\n</tr>&#13;\n<tr>&#13;\n<td>Майонез</td>&#13;\n<td>2 галлона</td>&#13;\n</tr>&#13;\n<tr>&#13;\n<td>Масло</td>&#13;\n<td>1 кварта</td>&#13;\n</tr>&#13;\n<tr>&#13;\n<td>Мёд</td>&#13;\n<td>1 галлон</td>&#13;\n</tr>&#13;\n<tr>&#13;\n<td>Пиво</td>&#13;\n<td>4 галлона</td>&#13;\n</tr>&#13;\n<tr>&#13;\n<td>Уксус</td>&#13;\n<td>2 галлона</td>&#13;\n</tr>&#13;\n</tbody>&#13;\n</table>&#13;\n</div>",
		Source = "«Candlekeep Mysteries»",
		Attunement = false,
		Type = MagicItemType.WondrousItem,
		Rarity = Rarity.Uncommon,
		Price = new RecomendedPrice() {
			Formula = "(1d6 + 1) * 100",
			MinPrice = 101,
			MaxPrice = 500
		}
	};
	public static MagicItem magicItemAmmunitionPlus1 { get; } = new MagicItem()
	{
		Id = Guid.Parse("2085ACAC-E31F-4B79-8697-A1B11082E153"),
		NameUa = "",
		DescriptionUa = "",
		Consumable = true,
		Charged = false,
		NameRus = "Боеприпасы +1",
		NameEng = "Ammunition +1",
		DescriptionUa1 = "<p> Ви отримуєте бонус <strong> +1 </strong> до кидків атаки та пошкодження, вчинених при використанні цих магічних боєприпасів.\n Потрапивши в ціль, боєприпаси перестають бути магічними. </p>",
		DescriptionRus1 = "<p>Вы получаете бонус <strong>+1</strong> к броскам атаки и урона, совершённым при использовании этих магических боеприпасов. Попав в цель, боеприпас перестаёт быть магическим.</p>",
		Source = "Руководство мастера",
		Attunement = false,
		Type = MagicItemType.Ammunition,
		Rarity = Rarity.Uncommon,
		MagicBonus = 1,
		Price = new RecomendedPrice() {
			Formula = "((1d6 + 1) * 100) / 2",
			MinPrice = 51,
			MaxPrice = 250
		}
	};
	public static MagicItem magicItemArmorPlus3 { get; } = new MagicItem()
	{
		Id = Guid.Parse("734186A0-38CD-4393-967B-A8A13A09D819"),
		NameUa = "",
		DescriptionUa = "",
		Consumable = false,
		Charged = false,
		NameRus = "Доспех +3",
		NameEng = "Armor +3",
		DescriptionUa1 = "<p> Більшість магічних броні є чудовими прикладами фізичного та магічного ремесла.\n Коли ви одягнені в таку броню, ви отримаєте додатковий бонус <strong> +3 </strong> на руку броні. </p>",
		DescriptionRus1 = "<p>Большинство волшебных доспехов являются превосходными образцами физического и магического ремесла. Когда вы одеты в такие доспехи, то получаете дополнительный бонус <strong>+3</strong> к Классу Доспеха.</p>",
		Source = "Руководство мастера",
		Attunement = false,
		Type = MagicItemType.Armour,
		Rarity = Rarity.Legendary,
        MagicBonus = 3,
        Price = new RecomendedPrice() {
			Formula = "2d6 * 25000",
			MinPrice = 50001,
			MaxPrice = 250000
		}
	};
	public static MagicItem magicItemBootsOftheWinterlands { get; } = new MagicItem()
	{
		Id = Guid.Parse("A66627B1-0634-45AB-BBE0-1D2E7118B6CF"),
		NameUa = "",
		DescriptionUa = "",
		Consumable = false,
		Charged = false,
		NameRus = "Заполярные сапоги",
		NameEng = "Boots of the Winterlands",
		DescriptionUa1 = "<p> Ці хутряні черевики дуже щільні та теплі.\n Поки ви їх носите, ви отримуєте такі переваги: </p> <ul> <li style = \"text-align: justify;\"> ви отримуєте <em> опір </em> пошкодження холодним. </li> <li style = \"text-align: justify;\"> ви ігноруєте <em> непрохідну область </em>, створену льодом або снігом. </li> <li style = \"text-align: justify;\"> ви зазвичай ви зазвичай ви зазвичай; терпіти таку низьку температуру - мінус; 50 & deg; f (& minus; 45 & deg; c), без додаткового теплого одягу.\n Якщо ви одягнені дуже тепло, ви можете перенести температуру на & minus; 100 & deg; f (& minus; 73 & deg; c). </li> </ul>",
		DescriptionUa2 = "<div itemprop = \"опис\"> <p> Ці хутряні черевики дуже щільні та теплі.\n Поки ви їх носите, ви отримуєте такі переваги: </p> &#13;\n<ul> &#13;\n<li> Ви отримуєте стійкість до пошкодження холодним. </li> &#13;\n<li> Ви ігноруєте <span tooltip-for = \"terrain.difficult\" title = \"terran.difficult\"> непрохідна область </span> створена льодом або снігом. </li> &#13;\n<li> Ви зазвичай переносите температуру до -50 ° F (-45 ° C) без теплого одягу.\n Якщо ви одягнені в теплий одяг, ви можете перенести температуру до -100 ° F (-73 ° C). </li> &#13;\n</ul> &#13;\n</div>",
		DescriptionRus1 = "<p>Эти меховые сапоги очень плотные и тёплые. Пока вы их носите, вы получаете следующие преимущества:</p><ul><li style=\"text-align: justify;\">Вы получаете <em>сопротивление</em> к урону холодом.</li><li style=\"text-align: justify;\">Вы игнорируете <em>труднопроходимую местность</em>, созданную льдом или снегом.</li><li style=\"text-align: justify;\">Вы нормально выносите такую низкую температуру как &minus;50 &deg;F (&minus;45 &deg;C), без дополнительной тёплой одежды. Если вы одеты очень тепло, то можете переносить температуру до &minus;100 &deg;F (&minus;73 &deg;C).</li></ul>",
		DescriptionRus2 = "<div itemprop=\"description\"><p>Эти меховые сапоги очень плотные и тёплые. Пока вы их носите, вы получаете следующие преимущества:</p>&#13;\n<ul>&#13;\n<li>Вы получаете сопротивление урону холодом.</li>&#13;\n<li>Вы игнорируете <span tooltip-for=\"terrain.difficult\" title=\"terrain.difficult\">труднопроходимую местность</span>, созданную льдом или снегом.</li>&#13;\n<li>Вы нормально переносите температуру до −50 °F (−45 °C) без тёплой одежды. Если вы одеты в теплую одежду, то можете переносить температуру до −100 °F (−73 °C).</li>&#13;\n</ul>&#13;\n</div>",
		Source = "«Dungeon master's guide»",
		Attunement = true,
		Type = MagicItemType.WondrousItem,
		Rarity = Rarity.Uncommon,
		Price = new RecomendedPrice() {
			Formula = "(1d6 + 1) * 100",
			MinPrice = 101,
			MaxPrice = 500
		}
	};
	public static MagicItem magicItemCloakOfInvisibility { get; } = new MagicItem()
	{
		Id = Guid.Parse("47C105E2-44FD-4E28-B0B1-C188F64DC66E"),
		NameUa = "",
		DescriptionUa = "",
		Consumable = false,
		Charged = false,
		NameRus = "Плащ невидимости",
		NameEng = "Cloak of Invisibility",
		DescriptionUa1 = "<p> Якщо ви носите цей плащ, ви можете покласти на капот на голову і стати <demand-tooltip type = \"екран\"> <a href=\"/screens/invisible\"> невидимі </a> <///detail- ToolTip>. </p> <p> Поки ви <dialytultip type = \"екран\"> <a href=\"/screens/invisible\"> невидимі </a> </dumstooltip>, все, що ви носите і Зверніться, з вами стає непомітним.\n Ви видно, якщо ви не надягаєте на капот. Залишайтеся невидимими, порціями 1 хвилини.\n Після 2 годин невидимості плащ перестає діяти.\n Кожні 12 годин, поки плащ не використовується, він відновлює 1 годину використання. </p>",
		DescriptionUa2 = "<div itemprop = \"опис\"> <p> Якщо ви носите цей плащ, ви можете надіти капюшон і стати <pan tooltip-for = \"condition.invisible\" title = \"condition.invisible\"> невидимий </span>.\n Поки ви невидимі, все, що ви носите та носите,-це <span tooltip-for = \"condation.invisible\" title = \"condation.invisible\"> Невидимий </span> з вами.\n Вас видно, якщо ви не носите капюшон.\n Капот носять і видаляється дією. </p> &#13;\n<p> simmop час, протягом якого ви залишаєтесь <span tooltip-for = \"condation.invisible\" title = \"condation.invisible\"> Невидимий </span>, частина 1 хвилини.\n Після 2 годин невидимості плащ перестає діяти.\n Протягом кожні 12 годин, поки не буде використаний дощо, він відновлює 1 годину використання. </p> &#13;\n</div>",
		DescriptionRus1 = "<p>Если вы носите этот плащ, вы можете надеть на голову капюшон и стать <detail-tooltip type=\"screen\"><a href=\"/screens/Invisible\">невидимым</a></detail-tooltip>.</p><p>Пока вы <detail-tooltip type=\"screen\"><a href=\"/screens/Invisible\">невидимы</a></detail-tooltip>, всё, что вы несёте и носите, становится невидимым вместе с вами. Вы видимы, если не надеваете капюшон.</p><p>Капюшон надевается и снимается <em>Действием</em>.</p><p>Суммируйте время, в течение которого вы остаётесь невидимы, порциями по 1 минуте. После 2 накопленных часов невидимости плащ перестаёт действовать. За каждые 12 часов, пока плащ не используется, он восстанавливает 1 час использования.</p>",
		DescriptionRus2 = "<div itemprop=\"description\"><p>Если вы носите этот плащ, вы можете надеть на голову капюшон и стать <span tooltip-for=\"condition.invisible\" title=\"condition.invisible\">невидимым</span>. Пока вы невидимы, всё, что вы несёте и носите, становится <span tooltip-for=\"condition.invisible\" title=\"condition.invisible\">невидимым</span> вместе с вами. Вы видимы, если не надеваете капюшон. Капюшон надевается и снимается действием.</p>&#13;\n<p>Суммируйте время, в течение которого вы остаётесь <span tooltip-for=\"condition.invisible\" title=\"condition.invisible\">невидимы</span>, порциями по 1 минуте. После 2 накопленных часов невидимости плащ перестаёт действовать. За каждые 12 часов, пока плащ не используется, он восстанавливает 1 час использования.</p>&#13;\n</div>",
		Source = "«Dungeon master's guide»",
		Attunement = true,
		Type = MagicItemType.WondrousItem,
		Rarity = Rarity.Legendary,
		Price = new RecomendedPrice() {
			Formula = "2d6 * 25000",
			MinPrice = 50001,
			MaxPrice = 250000
		}
	};
	public static MagicItem magicItemDwarvenPlate { get; } = new MagicItem()
	{
		Id = Guid.Parse("2ED1DB0D-7CA8-412B-BE42-88F52B706C5B"),
		NameUa = "",
		DescriptionUa = "",
		Consumable = false,
		Charged = false,
		NameRus = "Латы дварфов",
		NameEng = "Dwarven Plate",
		DescriptionUa1 = "<p> Коли ви носите цю броню, ви отримуєте бонус <strong> +2 </strong> на компакт -диск. Суцільна поверхня, ви можете <em> з реакцією </em> зменшить відстань, на яку ви будете переміщені на відстані 10 футів. </p> <p> & nbsp; </p>",
		DescriptionUa2 = "<div itemprop = \"опис\"> <p> Під час носіння цієї броні ви отримуєте бонус +2 на компакт -диск.\n Крім того, якщо певний ефект рухає вас проти вашої волі, і ви стоїте на твердій поверхні, ви можете зменшити відстань, яку ви будете переміщені на відстань до 10 футів. </p> &#13;\n</div>",
		DescriptionRus1 = "<p>Пока вы носите этот доспех, вы получаете бонус<strong> +2</strong> к КД.</p><p>Кроме того, если некий эффект перемещает вас против вашей воли, а вы стоите на твёрдой поверхности, вы можете <em>реакцией</em> уменьшит расстояние, на которое вас переместят, на расстояние до 10 футов.</p><p>&nbsp;</p>",
		DescriptionRus2 = "<div itemprop=\"description\"><p>Пока вы носите этот доспех, вы получаете бонус +2 к КД. Кроме того, если некий эффект перемещает вас против вашей воли, а вы стоите на твёрдой поверхности, вы можете реакцией уменьшит расстояние, на которое вас переместят, на расстояние до 10 футов.</p>&#13;\n</div>",
		Source = "«Dungeon master's guide»",
		Attunement = false,
		Type = MagicItemType.Armour,
		Rarity = Rarity.VeryRare,
		Price = new RecomendedPrice() {
			Formula = "(1d4 + 1) * 10000",
			MinPrice = 5001,
			MaxPrice = 50000
		}
	};
	public static MagicItem magicItemGemOfSeeing { get; } = new MagicItem()
	{
		Id = Guid.Parse("881CFDCB-BA9E-431A-B1D3-A3D5563D2505"),
		NameUa = "",
		DescriptionUa = "",
		Consumable = false,
		Charged = true,
		NameRus = "Камень зрения",
		NameEng = "Gem of Seeing",
		DescriptionUa1 = "<p> Цей дорогоцінний камінь має 3 заряди. </p> <p> Ви можете <em> з дією </em> вимовити командне слово і витратити 1 заряд.\n Протягом наступних 10 хвилин у вас є <strong> справжнє бачення </strong> в межах 120 футів, якщо переглянути цей дорогоцінний камінь. </p> <p> Камінь відновлює <formula kin-roller = \"1k3\"> 1K3 </ Кибки-роллер> заряд на світанку. </p>",
		DescriptionUa2 = "<div itemprop = \"опис\"> <p> Цей дорогоцінний камінь має 3 заряди.\n Ви можете сказати командне слово і витратити 1 заряд.\n Протягом наступних 10 хвилин у вас є <span tooltip-for = \"Vision.truevision\" title = \"Vision.truevision\"> True Vision </span> в межах 120 футів, якщо переглянути цей дорогоцінний камінь. </p> ### # 13;\n<p> Камінь щоденно відновлює заряд 1K3 на світанку. </p> &#13;\n</div>",
		DescriptionRus1 = "<p>У этого драгоценного камня есть 3 заряда.</p><p>Вы можете <em>Действием</em> произнести командное слово и потратить 1 заряд. В течение следующих 10 минут вы обладаете <strong>истинным зрением</strong> в пределах 120 футов, если смотрите через этот драгоценный камень.</p><p>Камень ежедневно восстанавливает <dice-roller formula=\"1к3\">1к3</dice-roller> заряда на рассвете.</p>",
		DescriptionRus2 = "<div itemprop=\"description\"><p>У этого драгоценного камня есть 3 заряда. Вы можете действием произнести командное слово и потратить 1 заряд. В течение следующих 10 минут вы обладаете <span tooltip-for=\"vision.truevision\" title=\"vision.truevision\">истинным зрением</span> в пределах 120 футов, если смотрите через этот драгоценный камень.</p>&#13;\n<p>Камень ежедневно восстанавливает 1к3 заряда на рассвете.</p>&#13;\n</div>",
		Source = "«Dungeon master's guide»",
		Attunement = true,
		Type = MagicItemType.WondrousItem,
		Rarity = Rarity.Rare,
		Price = new RecomendedPrice() {
			Formula = "2d10 * 1000",
			MinPrice = 501,
			MaxPrice = 5000
		}
	};
	public static MagicItem magicItemHelmOfTelepathy { get; } = new MagicItem()
	{
		Id = Guid.Parse("042E0460-B6D8-45E2-A9C4-273265DF2AEB"),
		NameUa = "",
		DescriptionUa = "",
		Consumable = false,
		Charged = false,
		NameRus = "Шлем телепатии",
		NameEng = "Helm of Telepathy",
		DescriptionUa1 = "<p> Поки що ви носите цей шолом, ви можете <em> за допомогою дії </em> покласти його із заклинанням <demand-tooltip type = \"заклинання\"> <a href=\"/spells/detect_thoughs\"> виявлення думок [Виявити хоч] </a> </dums-tooltip> (SL SPAS Брасс 13). </p> <p> Під час підтримки концентрації на цьому заклинанні ви можете <em> з бонусним ефектом </em > Надішліть телепатичне повідомлення істоті, на якій ви зосередилися.\n Він може відповісти <em> з бонусною дією </em> м, якщо ви продовжуєте зосереджуватися на цьому. заклинання на ньому \". Власність пропозиції знову до наступного світанку. </p>",
		DescriptionUa2 = "<div itemprop = \"опис\"> <p> Під час носіння цього шолома ви можете нав'язати на них заклинання <a href=\"/spells/196-detect_thüghts/\"> виявлення думок [виявити хоч] </a> 13 .).\n Поки ви підтримуєте концентрацію на цьому заклинанні, ви можете надіслати телепатичне повідомлення істоті, на якій ви зосередилися.\n Він може відповісти на бонусну дію, якщо ви продовжуєте зосереджуватися на ньому. </p> &#13;\n<p> Орієнтуючись на есе <em> виявлення думок </em>, ви можете покласти на нього заклинання з дією заклинання на ньому <a href=\"/spells/23-suggges/\"> пропозиція [пропозиція ] </a> (SL Spas Razbriska 13).\n Ви не можете використовувати властивість <em> пропозиції </em> неодноразово до наступного світанку. </p> &#13;\n</div>",
		DescriptionRus1 = "<p>Пока вы носите этот шлем, вы можете <em>Действием</em> накладывать им заклинание <detail-tooltip type=\"spell\"><a href=\"/spells/Detect_thoughts\">обнаружение мыслей [detect thoughts]</a></detail-tooltip> (Сл спасброска 13).</p><p>Пока вы поддерживаете концентрацию на этом заклинании, вы можете <em>бонусным действием</em> отправить телепатическое послание существу, на котором вы сосредоточились. Оно может ответить <em>бонусным действие</em>м, если вы продолжите сосредотачиваться на нём.</p><p>Сосредоточившись на существе обнаружением мыслей, вы можете действием наложить шлемом на него заклинание <detail-tooltip type=\"spell\"><a href=\"/spells/Suggestion\">внушение [suggestion]</a></detail-tooltip> (Сл спасброска 13).</p><p>Вы не можете использовать свойство внушения повторно до следующего рассвета.</p>",
		DescriptionRus2 = "<div itemprop=\"description\"><p>Пока вы носите этот шлем, вы можете действием накладывать им заклинание <a href=\"/spells/196-detect_thoughts/\">обнаружение мыслей [detect thoughts]</a> (Сл спасброска 13). Пока вы поддерживаете концентрацию на этом заклинании, вы можете бонусным действием отправить телепатическое послание существу, на котором вы сосредоточились. Оно может ответить бонусным действием, если вы продолжите сосредотачиваться на нём.</p>&#13;\n<p>Сосредоточившись на существе <em>обнаружением мыслей</em>, вы можете действием наложить шлемом на него заклинание <a href=\"/spells/23-suggestion/\">внушение [suggestion]</a> (Сл спасброска 13). Вы не можете использовать свойство <em>внушения </em>повторно до следующего рассвета.</p>&#13;\n</div>",
		Source = "«Dungeon master's guide»",
		Attunement = true,
		Type = MagicItemType.WondrousItem,
		Rarity = Rarity.Uncommon,
		Price = new RecomendedPrice() {
			Formula = "(1d6 + 1) * 100",
			MinPrice = 101,
			MaxPrice = 500
		}
	};
	public static MagicItem magicItemMaceOfSmiting { get; } = new MagicItem()
	{
		Id = Guid.Parse("A0DE6BC3-02D8-4485-A3DC-C8BDD9320B44"),
		NameUa = "",
		DescriptionUa = "",
		Consumable = false,
		Charged = false,
		NameRus = "Булава кары",
		NameEng = "Mace of Smiting",
		DescriptionUa1 = "<p> Ви отримуєте <strong> бонус +1 </strong> до кидків нападу та пошкодження, вчинених цією магічною зброєю. атаки <em> конструкція </em>. </p> <p> Якщо у вас є & laquo; <em> 20 </em> & raquo;\n При киданні атаки цією зброєю мету отримують додаткову руйнівну шкоду <em> 7 </em> або додаткову шкоду для дроблення <em> 14 </em>, якщо це була конструкція.\n Якщо конструкція має 25 або менше ударів після отримання цієї шкоди, вона знищена. </p>",
		DescriptionUa2 = "<Div itemprop = \"Опис\"> <p> Ви отримуєте бонус +1 на кидки нападу та пошкодження, вчинені цією магічною зброєю.\n Бонус збільшується до +3, якщо конструкція атакує. </p> &#13;\n<p> Якщо ви впадете \"20\", коли кидаєте атаку з цією зброєю, мета отримує додаткову подрібнювальну шкоду 7 або додаткову пошкодження 14, якщо це була конструкція.\n Якщо конструкція має 25 або менше ударів після отримання цієї шкоди, вона знищена. </p> &#13;\n</div>",
		DescriptionRus1 = "<p>Вы получаете<strong> бонус +1</strong> к броскам атаки и урона, совершённым этим магическим оружием.</p><p>Бонус увеличивается до <strong>+3</strong>, если атакуется <em>конструкт</em>.</p><p>Если у вас выпадает &laquo;<em>20</em>&raquo; при броске атаки этим оружием, цель получает дополнительный дробящий урон <em>7</em> или дополнительный дробящий урон <em>14</em>, если это был конструкт. Если у конструкта осталось 25 или меньше хитов после получения этого урона, он уничтожается.</p>",
		DescriptionRus2 = "<div itemprop=\"description\"><p>Вы получаете бонус +1 к броскам атаки и урона, совершённым этим магическим оружием. Бонус увеличивается до +3, если атакуется конструкт.</p>&#13;\n<p>Если у вас выпадает «20» при броске атаки этим оружием, цель получает дополнительный дробящий урон 7 или дополнительный дробящий урон 14, если это был конструкт. Если у конструкта осталось 25 или меньше хитов после получения этого урона, он уничтожается.</p>&#13;\n</div>",
		Source = "«Dungeon master's guide»",
		Attunement = false,
		Type = MagicItemType.MeleeWeapon,
		Rarity = Rarity.Rare,
		Price = new RecomendedPrice() {
			Formula = "2d10 * 1000",
			MinPrice = 501,
			MaxPrice = 5000
		}
	};
	public static MagicItem magicItemMaceOfTerror { get; } = new MagicItem()
	{
		Id = Guid.Parse("B218146B-656C-4ABD-A667-428758ECBEAA"),
		NameUa = "",
		DescriptionUa = "",
		Consumable = false,
		Charged = true,
		NameRus = "Булава ужаса",
		NameEng = "Mace of Terror",
		DescriptionUa1 = "<p> Ця зброя має <strong> 3 </strong> заряд.\n Якщо ви його тримаєте, ви можете <em> з дії </em> витратити 1 заряд, щоб звільнити хвилю жаху. </p> <p> Усі істоти для вашого вибору в межах 30 футів повинні досягти успіху в збереженні <клас класу = \"Saving_throw\"> мудрості </span> cl 15, інакше вони будуть <demand-tooltip type = \"екран\"> <a href=\"/frightenced\"> перелякані </a> </dumstooltip> протягом 1 хвилини.\n Будучи <demand-tooltip type = \"screen\"> <a href=\"/screens/frightenced\"> перелякані </a> </detail-toltip> таким чином істота повинна провести кроки, щоб рухатися як далеко від вас Як можливо, і не може добровільно рухатися в космос у межах 30 футів від вас.\n Він також не може зробити <em> реакцій </em>. </p> <p> з усіх його дій, істота може використовувати лише <fetail-tooltip type = \"екран\"> <a href = \"/екрани/тире\" > Перемикання </a> </dumstooltip> або намагання звільнити себе від ефекту, що перешкоджає його руху.\n Якщо ніде рухається, істота може використовувати дію <fetail-tooltip type = \"екран\"> <a href=\"/screens/dodge\"> ухилення </a> </dumstooltip>. </p> <p> В кінці істота може повторити кожен зі своїх ударів, помірний ефект з успіхом. </p> <p> macer відновлюється щодня <formula formula = \"1d3\"> 1k3 </bin-roller> на світанку. </p> </p> </p>",
		DescriptionUa2 = "<div itemprop = \"опис\"> <p> Ця зброя має 3 збори.\n Якщо ви його тримаєте, ви можете витратити 1 заряд із дією, щоб звільнити хвилю жаху.\n Усі істоти для вашого вибору в межах 30 футів повинні досягти успіху в збереженні мудрості SL 15, інакше вони стануть <span tooltip-for = \"condition.frighted\" title = \"умова.frightnend\"> переляканий </span> протягом 1 хвилини.\n Будучи <span tooltip-for = \"condition.frighted\" title = \"умова.frighted\"> переляканий </span> Таким чином істота повинна провести кроки, щоб рухатися як далеко від вас, і не може добровільно рухатися в космос в межах 30 футів від вас.\n Це також не може зробити реакції.\n З усіх своїх дій істота може використовувати лише <span tooltip-for = \"action.dash\" title = \"action.dash\"> прорив </span> або спробувати звільнити себе від ефекту, що запобігає його руху.\n Якщо ніде не рухається, істота може використовувати ефект <span tooltip-for = \"action.dodge\" title = \"action.dodge\"> ухилення </span>.\n В кінці кожного з своїх ударів істота може повторити порятунок, закінчуючи ефект успіхом. </p> &#13;\n<p> bulava daily відновлює заряд 1k3 на світанку. </p> &#13;\n</div>",
		DescriptionRus1 = "<p>У этого оружия есть <strong>3</strong> заряда. Если вы его держите, вы можете <em>Действием</em> потратить 1 заряд, чтобы испустить волну ужаса.</p><p>Все существа на ваш выбор в пределах 30 футов должны преуспеть в спасброске <span class=\"saving_throw\">Мудрости</span> со Сл 15, иначе станут <detail-tooltip type=\"screen\"><a href=\"/screens/Frightened\">испуганными</a></detail-tooltip> вами на 1 минуту. Будучи <detail-tooltip type=\"screen\"><a href=\"/screens/Frightened\">испуганным</a></detail-tooltip> таким способом, существо должно тратить ходы на то, чтобы переместиться как можно дальше от вас, и не может добровольно перемещаться в пространство в пределах 30 футов от вас. Оно также не может совершать <em>Реакции</em>.</p><p>Из всех своих действий существо может использовать только <detail-tooltip type=\"screen\"><a href=\"/screens/Dash\">Рывок</a></detail-tooltip> или пытаться освободиться от эффекта, препятствующего его передвижению. Если двигаться некуда, существо может использовать действие <detail-tooltip type=\"screen\"><a href=\"/screens/Dodge\">Уклонение</a></detail-tooltip>.</p><p>В конце каждого своего хода существо может повторять спасбросок, оканчивая эффект при успехе.</p><p>Булава ежедневно восстанавливает <dice-roller formula=\"1d3\">1к3</dice-roller> заряда на рассвете.</p>",
		DescriptionRus2 = "<div itemprop=\"description\"><p>У этого оружия есть 3 заряда. Если вы его держите, вы можете действием потратить 1 заряд, чтобы испустить волну ужаса. Все существа на ваш выбор в пределах 30 футов должны преуспеть в спасброске Мудрости Сл 15, иначе станут <span tooltip-for=\"condition.frightened\" title=\"condition.frightened\">испуганными</span> вами на 1 минуту. Будучи <span tooltip-for=\"condition.frightened\" title=\"condition.frightened\">испуганным</span> таким способом, существо должно тратить ходы на то, чтобы переместиться как можно дальше от вас, и не может добровольно перемещаться в пространство в пределах 30 футов от вас. Оно также не может совершать реакции. Из всех своих действий существо может использовать только <span tooltip-for=\"action.dash\" title=\"action.dash\">Рывок</span> или пытаться освободиться от эффекта, препятствующего его передвижению. Если двигаться некуда, существо может использовать действие <span tooltip-for=\"action.dodge\" title=\"action.dodge\">Уклонение</span>. В конце каждого своего хода существо может повторять спасбросок, оканчивая эффект при успехе.</p>&#13;\n<p>Булава ежедневно восстанавливает 1к3 заряда на рассвете.</p>&#13;\n</div>",
		Source = "«Dungeon master's guide»",
		Attunement = true,
		Type = MagicItemType.MeleeWeapon,
		Rarity = Rarity.Rare,
		Price = new RecomendedPrice() {
			Formula = "2d10 * 1000",
			MinPrice = 501,
			MaxPrice = 5000
		}
	};
	public static MagicItem magicItemOathbow { get; } = new MagicItem()
	{
		Id = Guid.Parse("2D2DFC7D-D74A-4539-A8CA-85602DDFCC7F"),
		NameUa = "",
		DescriptionUa = "",
		Consumable = false,
		Charged = false,
		NameRus = "Лук клятвы",
		NameEng = "Oathbow",
		DescriptionUa1 = "4 Зброя для виконання <em> Довга атака, </em> Ви можете сказати командну фразу: & laquo; <em> смерть, щоб зневажити мене </em> & raquo ;. через сім днів.\n Ви можете мати лише одного присяжного ворога одночасно. </p> <p> Якщо ваш присяжний ворог помирає, ви можете вибрати нове після наступного світанку. \"> Перевага </span>. </p> <p> Крім того, мета не отримує переваг від притулку, за винятком повного притулку, і ви не отримаєте штрафу за напад на відстані, що перевищує звичайний Відстань. </p> <p> Якщо напад падає, присяжний ворог отримує додаткові колючі пошкодження <formula ckip-roller = \"3k6\"> 3K6. </ живий, ви робите з <span class = \"недолік\"> перешкода </span> кидає нападу з усією іншою зброєю. </p>",
		DescriptionUa2 = "<div itemprop = \"опис\"> <p> Коли ви витягуєте бунструн цього лука, він шепоче мовою ельфійської мови: \"Я смерть ворогам\".\n Якщо ви використовуєте цю зброю, щоб зробити довгу атаку, ви можете сказати командну фразу: \"Смерть, щоб зневажати мене\".\n Мета вашого нападу стає вашим присяжним ворогом, поки він не помре, або поки світанок не настане через сім днів.\n Ви можете мати лише одного присяжного ворога одночасно.\n Якщо ваш присяжний ворог помирає, ви можете вибрати нове після наступного світанку. </p> &#13;\n<p> Якщо ви кидаєте довгу атаку на присягу ворога, ви робите це з перевагою.\n Крім того, мета не отримує переваг від притулку, за винятком <span tooltip-for = \"cover.full\" title = \"cover.full\"> Повний притулок </span>, і ви не отримаєте штраф за створення Атака на відстані, що перевищує звичайну відстань.\n Якщо напад впаде, присяжний ворог отримує додаткову шкоду уколу 3K6. </p> &#13;\n<p> Поки ваш присяжний ворог живий, ви робите атаку з перешкодою для всієї іншої зброї. </p> &#13;\n</div>",
		DescriptionRus1 = "<p>Когда вы натягиваете тетиву этого лука, он шепчет на Эльфийском языке: &laquo;<em>Несу смерть врагам</em>&raquo;.</p><p>Если вы используете это оружие для совершения<em> дальнобойной атаки, </em> вы можете сказать командную фразу: &laquo;<em>Смерть презревшему меня</em>&raquo;.</p><p>Цель вашей атаки становится вашим заклятым врагом, пока не умрёт, или пока не наступит рассвет по прошествии семи дней. У вас может быть только один заклятый враг одновременно.</p><p>Если ваш заклятый враг умирает, вы можете выбрать нового после следующего рассвета.</p><p>Если вы совершаете бросок <em>дальнобойной атаки</em> по заклятому врагу, вы совершаете его с <span class=\"advantage\">преимуществом</span>.</p><p>Кроме того, цель не получает преимуществ от укрытия, кроме полного укрытия, и вы не получаете штраф за совершение атаки на расстояние, превышающее обычную дистанцию.</p><p>Если атака попадает, заклятый враг получает дополнительный колющий урон <dice-roller formula=\"3к6\">3к6.</dice-roller></p><p>Пока ваш заклятый враг жив, вы совершаете с <span class=\"disadvantage\">помехой</span> броски атаки всем другим оружием.</p>",
		DescriptionRus2 = "<div itemprop=\"description\"><p>Когда вы натягиваете тетиву этого лука, он шепчет на Эльфийском языке: «Несу смерть врагам». Если вы используете это оружие для совершения дальнобойной атаки, вы можете сказать командную фразу: «Смерть презревшему меня». Цель вашей атаки становится вашим заклятым врагом, пока не умрёт, или пока не наступит рассвет по прошествии семи дней. У вас может быть только один заклятый враг одновременно. Если ваш заклятый враг умирает, вы можете выбрать нового после следующего рассвета.</p>&#13;\n<p>Если вы совершаете бросок дальнобойной атаки по заклятому врагу, вы совершаете его с преимуществом. Кроме того, цель не получает преимуществ от укрытия, кроме <span tooltip-for=\"cover.full\" title=\"cover.full\">полного укрытия</span>, и вы не получаете штраф за совершение атаки на расстояние, превышающее обычную дистанцию. Если атака попадает, заклятый враг получает дополнительный колющий урон 3к6.</p>&#13;\n<p>Пока ваш заклятый враг жив, вы совершаете с помехой броски атаки всем другим оружием.</p>&#13;\n</div>",
		Source = "«Dungeon master's guide»",
		Attunement = true,
		Type = MagicItemType.RangedWeapon,
		Rarity = Rarity.VeryRare,
		Price = new RecomendedPrice() {
			Formula = "(1d4 + 1) * 10000",
			MinPrice = 5001,
			MaxPrice = 50000
		}
	};
	public static MagicItem magicItemPotionOfClimbing { get; } = new MagicItem()
	{
		Id = Guid.Parse("321E61A0-6A4A-4565-B48E-657B0B8B2353"),
		NameUa = "",
		DescriptionUa = "",
		Consumable = true,
		Charged = false,
		NameRus = "Зелье лазания",
		NameEng = "Potion of Climbing",
		DescriptionUa1 = "4 Сильні> <em> сили (легка атлетика) </em> </strong>, ідеально піднімаються. </p> <p> Зілля -це триколірна рідина.\n Коричневі, срібні та сірі шари зі структурою нагадують малюнок на камені і не змішуйте разом, як би ви не струшуєте міхур. </p>",
		DescriptionUa2 = "<div itemprop = \"опис\"> <p> Коли ви п'єте це зілля, ви отримуєте 1 годину підйому на швидкість сходження, рівну вашій швидкості ходьби.\n Протягом цього часу ви робите з перевагою тестування (<span tooltip-for = \"skill.athletics\" title = \"skill.athletics\"> легка атлетика </span>), зобов’язаний піднятися.\n Зілля -це триколірна рідина.\n Коричневі, сріблясті та сірі шари зі структурою нагадують малюнок на камені і не змішуйте між собою, як би ви не струшуєте міхур. </p> &#13;\n</div>",
		DescriptionRus1 = "<p>Когда вы выпиваете это зелье, вы получаете на 1 час скорость лазания, равную вашей скорости ходьбы.</p><p>В течение этого времени вы совершаете с <span class=\"advantage\">преимуществом</span> проверки <strong><em>Силы (Атлетика)</em></strong>, совершённые, чтобы лезть.</p><p>Зелье представляет собой трёхцветную жидкость. Коричневый, серебряный и серый слои структурой напоминают рисунок на камне и не смешиваются между собой, как бы вы ни трясли пузырёк.</p>",
		DescriptionRus2 = "<div itemprop=\"description\"><p>Когда вы выпиваете это зелье, вы получаете на 1 час скорость лазания, равную вашей скорости ходьбы. В течение этого времени вы совершаете с преимуществом проверки Силы (<span tooltip-for=\"skill.athletics\" title=\"skill.athletics\">Атлетика</span>), совершённые, чтобы лезть. Зелье представляет собой трёхцветную жидкость. Коричневый, серебряный и серый слои структурой напоминают рисунок на камне и не смешиваются между собой, как бы вы ни трясли пузырёк.</p>&#13;\n</div>",
		Source = "«Dungeon master's guide»",
		Attunement = false,
		Type = MagicItemType.Potion,
		Rarity = Rarity.Common,
		Price = new RecomendedPrice() {
			Formula = "((1d6 + 1) * 10) / 2",
			MinPrice = 25,
			MaxPrice = 50
		}
	};
	public static MagicItem magicItemPotionOfFireBreath { get; } = new MagicItem()
	{
		Id = Guid.Parse("7D80141C-F3C9-4B80-AF12-BA1783B99DB1"),
		NameUa = "",
		DescriptionUa = "",
		Consumable = true,
		Charged = false,
		NameRus = "Зелье огненного дыхания",
		NameEng = "Potion of Fire Breath",
		DescriptionUa1 = "4 = \"Saving_throw\"> спритність </span> з SL 13, отримуючи пошкодження <Dice-Roller Formula = \"4K6\"> 4K6 </bin-Roller> з невдачею або половиною цієї шкоди з успіхом. </p> <p > Ефект закінчується після вас <strong> три рази </strong> використовуйте вогненне дихання, або через 1 годину. повзучи, коли ти не будеш без пробки. </p>",
		DescriptionUa2 = "<div itemprop = \"опис\"> <p> Після того, як ви випили це зілля, ви можете видалити пожежу на ціль, розташованій в межах 30 футів від вас, бонусною дією.\n Ціль повинна бути збережена спритністю SL 13, отримуючи шкоду 4K6 з вогнем з невдачею або половиною цієї шкоди з успіхом.\n Ефект закінчується після того, як ви тричі використовуєте вогненне дихання або через 1 годину. </p> &#13;\n4\n</div>",
		DescriptionRus1 = "<p>После того, как вы выпили это зелье, вы можете <em>бонусным действием</em> выдохнуть огонь на цель, находящуюся в пределах 30 футов от вас.</p><p>Цель должна совершить спасбросок <span class=\"saving_throw\">Ловкости</span> со Сл 13, получая урон огнём <dice-roller formula=\"4к6\">4к6</dice-roller> при провале или половину этого урона при успехе.</p><p>Эффект заканчивается после того, как вы <strong>трижды</strong> используете огненное дыхание, или по истечении 1 часа.</p><p>Зелье представляет собой оранжевую мерцающую жидкость, над которой стелется дымок, выходящий наружу каждый раз, когда вы откупориваете пробку.</p>",
		DescriptionRus2 = "<div itemprop=\"description\"><p>После того, как вы выпили это зелье, вы можете бонусным действием выдохнуть огонь на цель, находящуюся в пределах 30 футов от вас. Цель должна совершить спасбросок Ловкости Сл 13, получая урон огнём 4к6 при провале или половину этого урона при успехе. Эффект заканчивается после того, как вы трижды используете огненное дыхание, или по истечении 1 часа.</p>&#13;\n<p>Зелье представляет собой оранжевую мерцающую жидкость, над которой стелется дымок, выходящий наружу каждый раз, когда вы откупориваете пробку.</p>&#13;\n</div>",
		Source = "«Dungeon master's guide»",
		Attunement = false,
		Type = MagicItemType.Potion,
		Rarity = Rarity.Uncommon,
		Price = new RecomendedPrice() {
			Formula = "((1d6 + 1) * 100) / 2",
			MinPrice = 51,
			MaxPrice = 250
		}
	};
	public static MagicItem magicItemPotionOfGaseousForm { get; } = new MagicItem()
	{
		Id = Guid.Parse("5974B2EB-473C-40F3-856E-A1378BB36503"),
		NameUa = "",
		DescriptionUa = "",
		Consumable = true,
		Charged = false,
		NameRus = "Зелье газообразной формы",
		NameEng = "Potion of Gaseous Form",
		DescriptionUa1 = "4 /Деталі-touoltip> (концентрація не потрібна) протягом 1 години, або поки ви <em> з бонусним ефектом </em> не перебиваєте його.",
		DescriptionUa2 = "<div itemprop = \"опис\"> <p> Коли ви п'єте це зілля, ви отримуєте ефект заклинання <a href=\"/spells/41-gaseous_form/\"> газоподібної форми [газоподібна форма] </a> (концентрація не потрібно) протягом 1 години або до тих пір, поки ви не перерізає його бонусною дією.\n Пузир із цим зіллям, здається, містить туман, що тече, як вода. </p> &#13;\n</div>",
		DescriptionRus1 = "<p>Когда вы выпиваете это зелье, вы получаете эффект заклинания <detail-tooltip type=\"spell\"><a href=\"/spells/Gaseous_form\">газообразная форма [gaseous form]</a></detail-tooltip> (концентрация не требуется) на 1 час, или пока вы <em>бонусным действием</em> не прервёте его.</p><p>Пузырёк с этим зельем как будто содержит туман, перетекающий, словно вода.</p>",
		DescriptionRus2 = "<div itemprop=\"description\"><p>Когда вы выпиваете это зелье, вы получаете эффект заклинания <a href=\"/spells/41-gaseous_form/\">газообразная форма [gaseous form]</a> (концентрация не требуется) на 1 час, или пока вы бонусным действием не прервёте его. Пузырёк с этим зельем как будто содержит туман, перетекающий, словно вода.</p>&#13;\n</div>",
		Source = "«Dungeon master's guide»",
		Attunement = false,
		Type = MagicItemType.Potion,
		Rarity = Rarity.Rare,
		Price = new RecomendedPrice() {
			Formula = "(2d10 * 1000) / 2",
			MinPrice = 251,
			MaxPrice = 2500
		}
	};
	public static MagicItem magicItemPotionOfHealing { get; } = new MagicItem()
	{
		Id = Guid.Parse("E7E5F1E6-D511-471F-8350-0D89CE82E943"),
		NameUa = "",
		DescriptionUa = "",
		Consumable = true,
		Charged = false,
		NameRus = "Зелье лечения",
		NameEng = "Potion of Healing",
		DescriptionUa1 = "4 . << /p> <p> Зілля - це червона рідина, що іскрить при струшуванні. </p>",
		DescriptionUa2 = "<div itemprop = \"опис\"> <p> Ви відновлюєте хіти, коли п'єте це зілля.\n Кількість відновлених звернень залежить від рідкості зілля, як показано в таблиці \"лікувальних зілля\".\n Незалежно від сили зілля, це червона рідина, що іскрить при струшуванні. </p> &#13;\n<dable> &#13;\n<tbody> &#13;\n<tr class = \"table_head\"> <td> зілля ... </td> &#13;\n<td> рідкісні </td> &#13;\n<td> відновлені хіти </td> <td> ціна </td> &#13;\n</tr> &#13;\n<tr> &#13;\n<td> лікування </td> &#13;\n<td> звичайний </td> &#13;\n<td> 2k4 + 2 </td> <td> 50 </td> &#13;\n</tr> &#13;\n<tr> &#13;\n<td> Велике лікування </td> &#13;\n<td> незвичний </td> &#13;\n<td> 4k4 +4 </td> <td> 100 </td> &#13;\n</tr> &#13;\n<tr> &#13;\n<td> Велике лікування </td> &#13;\n<td> рідкісні </td> &#13;\n<td> 8k4 + 8 </td> <td> 500 </td> &#13;\n</tr> &#13;\n<tr> &#13;\n<td> Відмінне лікування </td> &#13;\n<td> Дуже рідко </td> &#13;\n<td> 10K4 + 20 </td> <td> 5000 </td> &#13;\n</tr> &#13;\n</tbody> &#13;\n</able> &#13;\n</div>",
		DescriptionRus1 = "<p>Вы восстанавливаете хиты, когда выпиваете это зелье.</p><p>Количество восстанавливаемых хитов <dice-roller label=\"Лечение\" formula=\"2d4+2\">2к4 + 2</dice-roller>.</p><p>Зелье представляет собой красную жидкость, сверкающую при встряхивании.</p>",
		DescriptionRus2 = "<div itemprop=\"description\"><p>Вы восстанавливаете хиты, когда выпиваете это зелье. Количество восстанавливаемых хитов зависит от редкости зелья, как показано в таблице «зелья лечения». Вне зависимости от силы зелья оно представляет собой красную жидкость, сверкающую при встряхивании.</p>&#13;\n<table>&#13;\n<tbody>&#13;\n<tr class=\"table_header\"><td>Зелье...</td>&#13;\n<td>Редкость</td>&#13;\n<td>Восстанавливаемые хиты</td><td>Цена</td>&#13;\n</tr>&#13;\n<tr>&#13;\n<td>лечения </td>&#13;\n<td>Обычное </td>&#13;\n<td>2к4 + 2</td><td>50</td>&#13;\n</tr>&#13;\n<tr>&#13;\n<td>большого лечения</td>&#13;\n<td>Необычное </td>&#13;\n<td>4к4 +4</td><td>100</td>&#13;\n</tr>&#13;\n<tr>&#13;\n<td>отличного лечения</td>&#13;\n<td>Редкое </td>&#13;\n<td>8к4 + 8</td><td>500</td>&#13;\n</tr>&#13;\n<tr>&#13;\n<td>превосходного лечения</td>&#13;\n<td>Очень редкое</td>&#13;\n<td>10к4 + 20</td><td>5000</td>&#13;\n</tr>&#13;\n</tbody>&#13;\n</table>&#13;\n</div>",
		Source = "«Dungeon master's guide»",
		Attunement = false,
		Type = MagicItemType.Potion,
		Rarity = Rarity.Common,
		Price = new RecomendedPrice() {
			Formula = "((1d6 + 1) * 10) / 2",
			MinPrice = 25,
			MaxPrice = 50
		}
	};
	public static MagicItem magicItemRingOfProtection { get; } = new MagicItem()
	{
		Id = Guid.Parse("280AFC85-4947-4F7B-A39D-FD501A27BA9E"),
		NameUa = "",
		DescriptionUa = "",
		Consumable = false,
		Charged = false,
		NameRus = "Кольцо защиты",
		NameEng = "Ring of Protection",
		DescriptionUa1 = "<p> Ви отримуєте бонус <strong> +1 </strong> на компакт -диск та брекети SPAS під час носіння цього кільця. </p>",
		DescriptionUa2 = "<div itemprop = \"опис\"> <p> Ви отримуєте бонус +1 на компакт -диск і порятунок, поки ви носите це кільце. </p> &#13;\n</div>",
		DescriptionRus1 = "<p>Вы получаете бонус<strong> +1</strong> к КД и спасброскам, пока носите это кольцо.</p>",
		DescriptionRus2 = "<div itemprop=\"description\"><p>Вы получаете бонус +1 к КД и спасброскам, пока носите это кольцо.</p>&#13;\n</div>",
		Source = "«Dungeon master's guide»",
		Attunement = true,
		Type = MagicItemType.Ring,
		Rarity = Rarity.Rare,
		Price = new RecomendedPrice() {
			Formula = "2d10 * 1000",
			MinPrice = 501,
			MaxPrice = 5000
		}
	};
	public static MagicItem magicItemRingOfWarmth { get; } = new MagicItem()
	{
		Id = Guid.Parse("C10AFF7C-E460-4CAD-A6E0-12316991C89A"),
		NameUa = "",
		DescriptionUa = "",
		Consumable = false,
		Charged = false,
		NameRus = "Кольцо тепла",
		NameEng = "Ring of Warmth",
		DescriptionUa1 = "<p>, носячи це кільце, у вас є <strong> опір </strong> пошкодження холодним. </p> <p> Крім того, ви і все, що ви носите та носите, не отримують шкоди від температури не нижче & мінус; 50 & deg; f (& minus; 45 & deg; c). </p>",
		DescriptionUa2 = "<div itemprop = \"опис\"> <p>, носивши це кільце, ви маєте стійкість до пошкодження холодним.\n Крім того, ви і все, що ви носите та носите, не отримуєте шкоди від температури не нижче -50 ° F (−45 ° C). </p> &#13;\n</div>",
		DescriptionRus1 = "<p>Нося это кольцо, вы обладаете <strong>сопротивлением</strong> к урону холодом.</p><p>Кроме того, вы и всё, что вы несёте и носите, не получают вреда от температур не ниже &minus;50 &deg;F (&minus;45 &deg;C).</p>",
		DescriptionRus2 = "<div itemprop=\"description\"><p>Нося это кольцо, вы обладаете сопротивлением урону холодом. Кроме того, вы и всё, что вы несёте и носите, не получают вреда от температур не ниже −50 °F (−45 °C).</p>&#13;\n</div>",
		Source = "«Dungeon master's guide»",
		Attunement = true,
		Type = MagicItemType.Ring,
		Rarity = Rarity.Uncommon,
		Price = new RecomendedPrice() {
			Formula = "(1d6 + 1) * 100",
			MinPrice = 101,
			MaxPrice = 500
		}
	};
	public static MagicItem magicItemRodOfRulership { get; } = new MagicItem()
	{
		Id = Guid.Parse("09C76D01-43F5-4655-BE16-EC5453E53AD8"),
		NameUa = "",
		DescriptionUa = "",
		Consumable = false,
		Charged = false,
		NameRus = "Жезл правления",
		NameEng = "Rod of Rulership",
		DescriptionUa1 = "4 span class = \"saving_throw\"> мудрість </span> с L 15, інакше вона стане <demand-tooltip type = \"екран\"> <a href=\"/screens/charmed\"> зачарування </a> </dems- Інструментарія> за 8 годин. </p> <p> Захоплюючись через цей ефект, істота вважає вас своїм справжнім лідером.\n Отримавши шкоду від вас або ваших супутників, або отримавши замовлення всупереч його природі, мета перестає захоплюватися цим ефектом. </p> <p> стрижень не може бути використаний знову до наступного світанку. </p >",
		DescriptionUa2 = "<div itemprop = \"опис\"> <p> Ви можете продемонструвати стрижень і вимагати покірності від усіх істот на ваш вибір, видно вами в межах 120 футів від себе.\n Кожна мета повинна досягти успіху в збереженні мудрості SL 15, інакше вона стане <span tooltip-for = \"condition.charmed\" title = \"умова.Charmed\"> Захоплений </span> протягом 8 годин.\n Будучи <span tooltip-for = \"умова.Charmed\" title = \"умова.Charmed\"> Захоплений </span> Через цей ефект істота вважає вас своїм справжнім лідером.\n Отримавши шкоду від вас або ваших супутників, або отримавши замовлення всупереч його природі, мета перестає захоплюватися цим ефектом.\n Стрижень не може бути використаний знову до наступного світанку. </p> &#13;\n</div>",
		DescriptionRus1 = "<p>Вы можете <em>Действием</em> продемонстрировать жезл и потребовать послушания от всех существ на ваш выбор, видимых вами в пределах 120 футов от себя.</p><p>Каждая цель должна преуспеть в спасброске <span class=\"saving_throw\">Мудрости</span> со Сл 15, иначе она станет <detail-tooltip type=\"screen\"><a href=\"/screens/Charmed\">очарованной</a></detail-tooltip> вами на 8 часов.</p><p>Будучи очарованным из-за этого эффекта, существо считает вас своим истинным предводителем. Получив урон от вас или ваших спутников, или получив приказ, противоречащий её природе, цель перестаёт быть очарованной этим эффектом.</p><p>Жезл нельзя использовать повторно до следующего рассвета.</p>",
		DescriptionRus2 = "<div itemprop=\"description\"><p>Вы можете действием продемонстрировать жезл и потребовать послушания от всех существ на ваш выбор, видимых вами в пределах 120 футов от себя. Каждая цель должна преуспеть в спасброске Мудрости Сл 15, иначе она станет <span tooltip-for=\"condition.charmed\" title=\"condition.charmed\">очарованной</span> вами на 8 часов. Будучи <span tooltip-for=\"condition.charmed\" title=\"condition.charmed\">очарованным</span> из-за этого эффекта, существо считает вас своим истинным предводителем. Получив урон от вас или ваших спутников, или получив приказ, противоречащий её природе, цель перестаёт быть очарованной этим эффектом. Жезл нельзя использовать повторно до следующего рассвета.</p>&#13;\n</div>",
		Source = "«Dungeon master's guide»",
		Attunement = true,
		Type = MagicItemType.Rod,
		Rarity = Rarity.Rare,
		Price = new RecomendedPrice() {
			Formula = "2d10 * 1000",
			MinPrice = 501,
			MaxPrice = 5000
		}
	};
	public static MagicItem magicItemSentinelShield { get; } = new MagicItem()
	{
		Id = Guid.Parse("A538FBFA-0A9C-402A-8B3D-08EBEF90A457"),
		NameUa = "",
		DescriptionUa = "",
		Consumable = false,
		Charged = false,
		NameRus = "Щит часового",
		NameEng = "Sentinel Shield",
		DescriptionUa1 = "<p> Поки ви тримаєте цей щит, ви робите <span class = \"Advanatage\"> перевага </span> Перевірка ініціативи та перевірка <em> мудрості (уважність) </em>. </p> <p> Сам щит, прикрашений символом ока. </p>",
		DescriptionUa2 = "<div itemprop = \"опис\"> <p> Поки ви тримаєте цей щит, ви робите з перевагою перевірки ініціативи та перевірки мудрості (<span tooltip-for = \"skill.perception\" title = \"skill.perception\"> сприйняття </span>).\n Сам щит прикрашений символом ока. </p> &#13;\n</div>",
		DescriptionRus1 = "<p>Пока вы держите этот щит, вы совершаете с <span class=\"advanatage\">преимуществом</span> проверки инициативы и проверки <em>Мудрости (Внимательность)</em>.</p><p>Сам щит украшен символом глаза.</p>",
		DescriptionRus2 = "<div itemprop=\"description\"><p>Пока вы держите этот щит, вы совершаете с преимуществом проверки инициативы и проверки Мудрости (<span tooltip-for=\"skill.perception\" title=\"skill.perception\">Восприятие</span>). Сам щит украшен символом глаза.</p>&#13;\n</div>",
		Source = "«Dungeon master's guide»",
		Attunement = true,
		Type = MagicItemType.Shield,
		Rarity = Rarity.Uncommon,
		Price = new RecomendedPrice() {
			Formula = "(1d6 + 1) * 100",
			MinPrice = 101,
			MaxPrice = 500
		}
	};
	public static MagicItem magicItemSpellScroll5thLevel { get; } = new MagicItem()
	{
		Id = Guid.Parse("EDB1C8CF-7DC5-40AA-B678-D887B5F91960"),
		NameUa = "",
		DescriptionUa = "",
		Consumable = false,
		Charged = false,
		NameRus = "Свиток заклинания (5 уровень)",
		NameEng = "Spell Scroll (5th level)",
		DescriptionUa1 = "<p> Прокрутка заклинання містить слова одного заклинання, написаного таємничим шифром.\n Якщо це заклинання є у списку заклинань вашого класу, ви можете прочитати прокрутку і застосувати його заклинання без надання матеріальних компонентів. </p> <p> <strong> SL Spasbravka: </strong> 17, бонус нападу : <Formula formula = \"k20 + 9\"> + 9 </bin-roller> </p> <p> інакше прокрутка для вас незрозуміла.\n Поставлення заклинання з толстовкою займає стільки часу, скільки звичайне заклинання.\n Після накладення заклинання слова на сувій зникають, і сам прокрутка руйнується до пилу. Але він має більш високий рівень, ніж ті, які ви можете нав'язати, ви повинні перевірити основну характеристику, щоб визначити, чи вдалося вам впоратися з завданням.\n SL такої перевірки - 10 + рівень заклинання.\n З невдачею заклинання просто зникає з прокрутки, не роблячи ніяких ефектів. </p> <p> Якщо прокрутка містить заклинання зі списку, тоді його можна скопіювати в книгу заклинань.\n Для цього вам потрібно досягти успіху в перевірці <strong> <em> інтелекту (магія) </em> </strong>, SL з яких 15. Якщо перевірка успішна, заклинання можна скопіювати.\n Незалежно від результату перевірки, сувої знищується після цього. </p>",
		DescriptionRus1 = "<p>Свиток заклинания несёт на себе слова одного заклинания, написанные таинственным шифром. Если это заклинание есть в списке заклинаний вашего класса, вы можете прочитать свиток и наложить его заклинание, не предоставляя материальные компоненты.</p><p><strong>Сл спасброска:</strong> 17, Бонус атаки: <dice-roller formula=\"к20 + 9\">+9</dice-roller></p><p>В противном случае свиток непонятен для вас. Накладывание заклинания свитком занимает столько же времени, сколько обычное накладывание заклинания. После того, как заклинание наложено, слова на свитке исчезают, а сам свиток рассыпается в прах.</p><p>Если накладывание прервано, свиток остаётся целым.</p><p>Если заклинание есть в списке заклинаний вашего класса, но имеет более высокий уровень, чем те, что вы способны накладывать, вы должны совершить проверку базовой характеристики, чтобы определить, удалось ли вам справиться с задачей. Сл такой проверки равна 10 + уровень заклинания. При провале заклинание просто исчезает со свитка, не произведя никаких эффектов.</p><p>Если свиток содержит заклинание из списка заклинаний волшебника, то оно может быть скопировано в книгу заклинаний. Для этого надо преуспеть в проверке <strong><em>Интеллекта (Магия)</em></strong>, Сл которой равна 15. Если проверка успешна, заклинание удаётся скопировать. Вне зависимости от исхода проверки свиток после этого уничтожается.</p>",
		Source = "Руководство мастера",
		Attunement = false,
		Type = MagicItemType.Scroll,
		Rarity = Rarity.Rare,
		Price = new RecomendedPrice() {
			Formula = "2d10 * 1000",
			MinPrice = 501,
			MaxPrice = 5000
		}
	};
	public static MagicItem magicItemStaffOfThePython { get; } = new MagicItem()
	{
		Id = Guid.Parse("94415A99-880A-4B5E-9030-21F1E0EE5FEB"),
		NameUa = "",
		DescriptionUa = "",
		Consumable = false,
		Charged = false,
		NameRus = "Посох питона",
		NameEng = "Staff of the Python",
		DescriptionUa1 = "4 > <a hreaf = \"/bestiari/giant_constrictor_snake\"> гігантський кондиціонер Boa [Giant Constrictorsnake] </a> </dealtoooltip> під вашим контролем, і він має своє місце в ініціативі. </em> командне слово знову, ви Поверніть свій природний вигляд персоналу, і він буде лежати в космосі, який раніше займався Бува. Футів від вас і здатний.\n Ви визначаєте, які дії взяти його і куди рухатися в наступному кроці, або ви можете дати спільну команду, наприклад, Laquo; Attack Wearies & Raquo;\n або & laquo; захистити місце & raquo;.\n Персонал розділений на шматки і знищується. </p> <p> Якщо змія стає персоналу, перш ніж вона втратить усі хіти, вона негайно їх відновлює. </p>",
		DescriptionUa2 = "<div itemprop = \"опис\"> <p> Ви можете сказати командне слово і кинути персонал на підлогу в межах 10 футів від себе.\n Персонал стає <a href=\"/bestiari/360-giant_constrictor_snake/\" target=\"_blank\"> гігантський кондиціонер Boa [гігантський констептор змія] </a> під вашим контролем і має своє місце в ініціативі.\n Знову виголосивши командне слово з бонусною дією, ви повертаєте його природний вигляд персоналу, і воно буде лежати в просторі, який раніше займався Бававром. </p> &#13;\n4\n Ви визначаєте, які дії взяти його і куди рухатися в наступному кроці, або ви можете дати спільну команду, наприклад, \"атакувати ворогів\" або \"захистити місце\".\n Якщо хіти змії падають до 0, вона помирає і стає персоналу. </p> &#13;\n<p> Персонал розділений на шматки і знищується.\n Якщо змія стає персоналу до того, як вона втратить усі хіти, вона негайно їх відновлює. </p> &#13;\n</div>",
		DescriptionRus1 = "<p>Вы можете <em>Действием</em> произнести командное слово и бросить посох на пол в пределах 10 футов от себя.</p><p>Посох становится <detail-tooltip type=\"creature\"><a href=\"/bestiary/Giant_constrictor_snake\">гигантским удавом [giant constrictorsnake]</a></detail-tooltip> под вашим контролем и у него есть своё место в порядке инициативы.</p><p>Произнеся <em>бонусным действием</em> командное слово ещё раз, вы возвращаете посоху его естественный облик, и он будет лежать в пространстве, ранее занимаемом удавом.</p><p>В свой ход вы можете мысленно отдавать команды удаву, если он находится в пределах 60 футов от вас и дееспособен. Вы определяете, какие действия ему совершать и куда перемещаться в следующем ходу, или же можете отдать общую команду, такую как &laquo;нападай на врагов&raquo; или &laquo;охраняй место&raquo;.</p><p>Если хиты змеи опустятся до 0, она умирает и становится посохом. Посох при этом раскалывается на куски и уничтожается.</p><p>Если змея становится посохом до того как потеряет все хиты, она их тут же восстанавливает.</p>",
		DescriptionRus2 = "<div itemprop=\"description\"><p>Вы можете действием произнести командное слово и бросить посох на пол в пределах 10 футов от себя. Посох становится <a href=\"/bestiary/360-giant_constrictor_snake/\" target=\"_blank\">гигантским удавом [giant constrictor snake]</a> под вашим контролем и у него есть своё место в порядке инициативы. Произнеся бонусным действием командное слово ещё раз, вы возвращаете посоху его естественный облик, и он будет лежать в пространстве, ранее занимаемом удавом.</p>&#13;\n<p>В свой ход вы можете мысленно отдавать команды удаву, если он находится в пределах 60 футов от вас и дееспособен. Вы определяете, какие действия ему совершать и куда перемещаться в следующем ходу, или же можете отдать общую команду, такую как «нападай на врагов» или «охраняй место». Если хиты змеи опустятся до 0, она умирает и становится посохом.</p>&#13;\n<p>Посох при этом раскалывается на куски и уничтожается. Если змея становится посохом до того как потеряет все хиты, она их тут же восстанавливает.</p>&#13;\n</div>",
		Source = "«Dungeon master's guide»",
		Attunement = true,
		Type = MagicItemType.Staff,
		Rarity = Rarity.Uncommon,
		Price = new RecomendedPrice() {
			Formula = "(1d6 + 1) * 100",
			MinPrice = 101,
			MaxPrice = 500
		}
	};
	public static MagicItem magicItemViciousWeapon { get; } = new MagicItem()
	{
		Id = Guid.Parse("CE5F1FDD-AC9C-49A2-9539-65F76F1FE7D6"),
		NameUa = "",
		DescriptionUa = "",
		Consumable = false,
		Charged = false,
		NameRus = "Жестокое оружие",
		NameEng = "Vicious Weapon",
		DescriptionUa1 = "<p> Якщо у вас є <strong> & laquo; 20 & raquo; </strong> при киданні атаки цієї магічної зброї гол отримує додаткову шкоду <span class = \"dice_text\"> 7 </span> тип Це викликає цю зброю. </p>",
		DescriptionUa2 = "<div itemprop = \"опис\"> <p> Якщо у вас є \"20\", коли ви кидаєте атаку на цю магічну зброю, ціль отримує додаткові 7 пошкоджень типу, який ця зброя завдає. </p> &#13;\n</div>",
		DescriptionRus1 = "<p>Если у вас при броске атаки этим магическим оружием выпадает <strong>&laquo;20&raquo;</strong>, цель получает дополнительный урон <span class=\"dice_text\">7</span> того вида, который причиняет это оружие.</p>",
		DescriptionRus2 = "<div itemprop=\"description\"><p>Если у вас при броске атаки этим магическим оружием выпадает «20», цель получает дополнительные 7 урона того вида, который наносит это оружие.</p>&#13;\n</div>",
		Source = "«Dungeon master's guide»",
		Attunement = false,
		Type = MagicItemType.Weapon,
		Rarity = Rarity.Rare,
		Price = new RecomendedPrice() {
			Formula = "2d10 * 1000",
			MinPrice = 501,
			MaxPrice = 5000
		}
	};
	public static MagicItem magicItemIounStone { get; } = new MagicItem()
	{
        Id = Guid.Parse("C3393876-FE02-428A-9FED-E14ADB9D8F95"),
        NameUa = "",
		DescriptionUa = "",
		Consumable = false,
		Charged = false,
		NameRus = "Камень Йоун",
		NameEng = "Ioun Stone",
		DescriptionUa1 = "<p> Існує кілька варіантів для цієї теми, як зазначено нижче: </p> <ul> <a href=\"/items/magic/iun_stone ,_awarence\"> yon камінь, сприйняття [ioon stone, обізнаний] </a > </li> <li> <a href=\"/items/magic/ioun_stone, _proctection\"> yun камінь, захист & nbsp; [ioon камінь, захист] </a> </li> <li> <a href = \"/предмети/magic/ioon_stone, _sustenance\"> joun Stone, харчування [iun камінь, харчування] </a> </li> <ah> <a href=\"/magic/iun_stone._reserv\"> yun stone, резерв [ioon Stone, резерв] </a> </li> <a href=\"/magic/ioon_stone ,_leadership, Лідерство [Камінь, Лідерство Стач </a> </li> <hi> <a href = \"/ magic/imagic/iun_stone, _absorption \"> yun камінь, поглинання & nbsp; [ioon камінь, поглинання] </a> </li> <li> <a href/magic /ioon_stone, _agility \"> joun stone, поворот [iun Камінь, спритність] </a> </li> <li> <a href=\"/magic/ioun_stone ,_insight\"> Юнь Стоун, Інсайт [Іоун Стоун Інсайт] </a> </li> <ah> <a href = \"/items/magic/iun_stone._intellect\"> yun Stone, причина & nbsp; [ioon sto\n Ne, Intellect] </a> </li> <ah> <a href=\"/magic/ioon_stone._strengith\"> кам'яний юн, сила & nbsp; [ioon камінь, сила] </a> </li> < li> <a href=\"/items/magic/ioon_stone._fortite\"> yone stone, stamina & nbsp; [ioon stone, foretette] </a> </li> <li> <a href = \"/предмети/магія /ioon_stone, _greater_absorption \"> стислий камінь, велике поглинання & nbsp; [ioon Stone, більше поглинання] </a> </li> <ah> <a href=\"/magic/iun_stone, _mastery\"> кам'яна юна, навичка [навичка [навичка [навичка [навичка [навичка [навичка [навичка [навичка [ Mastery Iunon Stone] </a> </li> <ahi> <a href=\"/items/magic/ioon_stone._regeeneration\"> yon stone, Regeneration & nbsp; [ioon Stone, Regeneration] </a> </li > </ul>",
		DescriptionRus1 = "<p>Существует несколько вариантов этого предмета, как указано ниже:</p><ul><li><a href=\"/items/magic/ioun_stone,_awareness\">Камень Йоун, восприятие [Ioun Stone, Awareness]</a></li><li><a href=\"/items/magic/ioun_stone,_protection\">Камень Йоун, защита&nbsp;[Ioun Stone, Protection]</a></li><li><a href=\"/items/magic/ioun_stone,_sustenance\">Камень Йоун, питания [Ioun Stone, Sustenance]</a></li><li><a href=\"/items/magic/ioun_stone,_reserve\">Камень Йоун, резерв [Ioun Stone, Reserve]</a></li><li><a href=\"/items/magic/ioun_stone,_leadership\">Камень Йоун, лидерство [Ioun Stone, Leadership]</a></li><li><a href=\"/items/magic/ioun_stone,_absorption\">Камень Йоун, поглощение&nbsp;[Ioun Stone, Absorption]</a></li><li><a href=\"/items/magic/ioun_stone,_agility\">Камень Йоун, проворство [Ioun Stone, Agility]</a></li><li><a href=\"/items/magic/ioun_stone,_insight\">Камень Йоун, проницательность [Ioun Stone, Insight]</a></li><li><a href=\"/items/magic/ioun_stone,_intellect\">Камень Йоун, рассудок&nbsp;[Ioun Stone, Intellect]</a></li><li><a href=\"/items/magic/ioun_stone,_strength\">Камень Йоун, сила&nbsp;[Ioun Stone, Strength]</a></li><li><a href=\"/items/magic/ioun_stone,_fortitude\">Камень Йоун, стойкость&nbsp;[Ioun Stone, Fortitude]</a></li><li><a href=\"/items/magic/ioun_stone,_greater_absorption\">Камень Йоун, большое поглощение&nbsp;[Ioun Stone, Greater Absorption]</a></li><li><a href=\"/items/magic/ioun_stone,_mastery\">Камень Йоун, мастерство [Ioun Stone, Mastery]</a></li><li><a href=\"/items/magic/ioun_stone,_regeneration\">Камень Йоун, регенерация&nbsp;[Ioun Stone, Regeneration]</a></li></ul>",
		DescriptionRus2 = "<div itemprop=\"description\"><p>Камень Йоун назван в честь богини знаний и пророчеств, почитаемой в нескольких мирах. Существует много разновидностей камней Йоун, все они отличаются по форме и цвету.</p>&#13;\n<p>Если вы действием подбрасываете один из этих камней в воздух, он начинает вращаться вокруг вашей головы на расстоянии 1к3 футов, предоставляя вам постоянное преимущество. Впоследствии другое существо может действием схватить руками или чем-то иным камень, забирая его себе, если совершит успешный бросок атаки по КД 24 или совершит успешную проверку Ловкости (<span tooltip-for=\"skill.acrobatics\" title=\"skill.acrobatics\">Акробатика</span>) Сл 24. Вы сами можете действием схватить и убрать камень, оканчивая его эффект.</p>&#13;\n<p>У камня КД 24, 10 хитов и сопротивление ко всем видам урона. Пока он вращается вокруг вашей головы, он считается носимым.</p>&#13;\n&#13;\n<div data-sort=\"block\" data-name=\"items.ioun_stone\">&#13;\n\t<div class=\"inline-links\" data-sort=\"sorter\" data-name=\"items.ioun_stone.sort\">&#13;\n\t\t<span class=\"inline-links__title\">Сортировка:</span>&#13;\n\t\t<ul class=\"inline-links__list\">&#13;\n\t\t\t<li class=\"inline-links__item\" data-sort=\"option\" data-sort-function=\"rarity\"><a>По редкости</a></li>&#13;\n\t\t\t<li class=\"inline-links__item\" data-sort=\"option\" data-sort-function=\"rname\" data-sort-default=\"1\"><a>По названию</a></li>&#13;\n\t\t</ul>&#13;\n\t</div> &#13;\n&#13;\n\t<div class=\"inline-links\" data-sort=\"multifilter\" data-name=\"items.ioun_stone.source\" data-field=\"data-source\">&#13;\n\t\t<span class=\"inline-links__title\">Источники:</span>&#13;\n\t\t<ul class=\"inline-links__list\">&#13;\n\t\t\t<li class=\"inline-links__item\" data-sort=\"option\" data-sort-function=\"DMG\" data-sort-default=\"1\"><a>DMG</a></li>&#13;\n\t\t\t<li class=\"inline-links__item\" data-sort=\"option\" data-sort-function=\"LLK\" data-sort-default=\"1\"><a>LLK</a></li>&#13;\n\t\t\t<li class=\"inline-links__item\" data-sort=\"option\" data-sort-function=\"IFR\" data-sort-default=\"1\"><a>IFR</a></li>&#13;\n\t\t</ul>&#13;\n\t</div> \t&#13;\n\t&#13;\n<div data-sort=\"container\">&#13;\n&#13;\n<div data-sort=\"element\" data-rarity=\"5\" data-source=\"DMG\">&#13;\n<p><strong><em>Большое поглощение (легендарный)</em></strong>. Пока этот эллипсоид с зелёными и лавандовыми прожилками вращается вокруг вашей головы, вы можете реакцией отменить заклинание с уровнем не больше 8, наложенное видимым вами существом и нацеленное только на вас.</p>&#13;\n<p>Если вы становитесь целью заклинания, чей уровень настолько большой, что камень не может поглотить его целиком, это заклинание нельзя отменить. Как только камень отменит 50 уровней заклинаний, он выгорит и станет тускло-серым, потеряв всю магию. </p>&#13;\n</div>&#13;\n<div data-sort=\"element\" data-rarity=\"3\" data-source=\"DMG\">&#13;\n<p><strong><em>Восприятие (редкий)</em></strong>. Пока этот тёмно-синий ромбоид вращается вокруг вашей головы, вы не можете быть захвачены врасплох.</p>&#13;\n</div>&#13;\n<div data-sort=\"element\" data-rarity=\"3\" data-source=\"DMG\">&#13;\n<p><strong><em>Защита (редкий)</em></strong>. Пока эта серо-розовая призма вращается вокруг вашей головы, вы получаете бонус +1 к КД.</p>&#13;\n</div>&#13;\n<div data-sort=\"element\" data-rarity=\"4\" data-source=\"DMG\">&#13;\n<p><strong><em>Лидерство (очень редкий)</em></strong>. Пока эта сфера с розовыми и зелёными прожилками вращается вокруг вашей головы, ваше значение Харизмы увеличивается на 2, с максимумом 20.</p>&#13;\n</div>&#13;\n<div data-sort=\"element\" data-rarity=\"5\" data-source=\"DMG\">&#13;\n<p><strong><em>Мастерство (легендарный)</em></strong>. Пока эта бледно-зелёная призма вращается вокруг вашей головы, ваш бонус мастерства увеличивается на 1.</p>&#13;\n</div>&#13;\n<div data-sort=\"element\" data-rarity=\"3\" data-source=\"DMG\">&#13;\n<p><strong><em>Питание (редкий)</em></strong>. Пока этот прозрачный веретенообразный камень вращается вокруг вашей головы, вам не нужно ни есть, ни пить.</p>&#13;\n</div>&#13;\n<div data-sort=\"element\" data-rarity=\"4\" data-source=\"DMG\">&#13;\n<p><strong><em>Поглощение (очень редкий)</em></strong>. Пока этот бледно-лавандовый эллипсоид вращается вокруг вашей головы, вы можете реакцией отменить заклинание с уровнем не больше 4-го, наложенное видимым вами существом и нацеленное только на вас.</p>&#13;\n<p>Если вы становитесь целью заклинания, чей уровень настолько большой, что камень не может поглотить его целиком, это заклинание нельзя отменить. Как только камень отменит 20 уровней заклинаний, он выгорит и станет тускло-серым, потеряв всю магию. </p>&#13;\n</div>&#13;\n<div data-sort=\"element\" data-rarity=\"4\" data-source=\"DMG\">&#13;\n<p><strong><em>Проворство (очень редкий)</em></strong>. Пока эта тёмно-красная сфера вращается вокруг вашей головы, ваше значение Ловкости увеличивается на 2, с максимумом 20.</p>&#13;\n</div>&#13;\n<div data-sort=\"element\" data-rarity=\"4\" data-source=\"DMG\">&#13;\n<p><strong><em>Проницательность (очень редкий)</em></strong>. Пока эта ярко-синяя сфера вращается вокруг вашей головы, ваше значение Мудрости увеличивается на 2, с максимумом 20.</p>&#13;\n</div>&#13;\n<div data-sort=\"element\" data-rarity=\"4\" data-source=\"DMG\">&#13;\n<p><strong><em>Рассудок (очень редкий)</em></strong>. Пока эта сфера с алыми и синими прожилками вращается вокруг вашей головы, ваше значение Интеллекта увеличивается на 2, с максимумом 20.</p>&#13;\n</div>&#13;\n<div data-sort=\"element\" data-rarity=\"5\" data-source=\"DMG\">&#13;\n<p><strong><em>Регенерация (легендарный)</em></strong>. Вы восстанавливаете 15 хитов в конце каждого часа, в течение которого этот жемчужно-белый веретенообразный камень вращается вокруг вашей головы, при условии, что у вас есть как минимум 1 хит.</p>&#13;\n</div>&#13;\n<div data-sort=\"element\" data-rarity=\"3\" data-source=\"DMG\">&#13;\n<p><strong><em>Резерв (редкий)</em></strong>. Эта ярко-фиолетовая призма хранит заклинания, наложенные в неё, пока вы не используете их. Этот камень может хранить до 3-х уровней заклинаний одновременно. Когда его находят, он хранит 1к4 - 1 уровень заклинаний, выбранных Мастером.</p>&#13;\n<p>Любое существо может заложить в камень заклинание с уровнем от 1-го до 3-го, касаясь его при накладывании. Заклинание не вступает в силу, а просто помещается в камень. Если камень не может уместить заклинание, заклинание тратится безо всякого эффекта. Занимаемое число уровней определяется уровнем, с которым заклинание было наложено.</p>&#13;\n<p>Пока этот камень вращается вокруг вашей головы, вы можете наложить заклинание, хранящееся в нём. Заклинание использует уровень ячейки, Сл спасброска, бонус атаки заклинанием и базовую характеристику исходного заклинателя, но во всём остальном считается, что заклинание наложили вы. Наложенное заклинание перестаёт храниться в камне, освобождая пространство.</p>&#13;\n</div>&#13;\n<div data-sort=\"element\" data-rarity=\"4\" data-source=\"DMG\">&#13;\n<p><strong><em>Сила (очень редкий)</em></strong>. Пока этот бледно синий ромбоид вращается вокруг вашей головы, ваше значение Силы увеличивается на 2, с максимумом 20.</p>&#13;\n</div>&#13;\n<div data-sort=\"element\" data-rarity=\"4\" data-source=\"DMG\">&#13;\n<p><strong><em>Стойкость (очень редкий)</em></strong>. Пока этот розовый ромбоид вращается вокруг вашей головы, ваше значение Телосложения увеличивается на 2, с максимумом 20.</p>&#13;\n</div>&#13;\n<div data-sort=\"element\" data-rarity=\"4\" data-source=\"IFR\">&#13;\n<p><strong><em>Живучесть (очень редкий) <span title=\"Infernal Machine Rebuild\" class=\"tooltip\">[IMR]</span></em></strong>. Пока эта сине-зелёная мраморная сфера вращается вокруг вашей головы, вы получаете бонус +1 к спасброскам от смерти.</p>&#13;\n</div>&#13;\n<div data-sort=\"element\" data-rarity=\"3\" data-source=\"LLK\">&#13;\n<p><strong><em>Высший интеллект (редкий) <span title=\"Lost Laboratory of Kwalish\" class=\"tooltip\">[LLK]</span></em></strong>. Пока эта гранёная сфера вращается вокруг вашей головы, вы получаете бонус +1 к проверкам Интеллекта.</p>&#13;\n</div>&#13;\n<div data-sort=\"element\" data-rarity=\"3\" data-source=\"LLK\">&#13;\n<p><strong><em>Знание истории (редкий) <span title=\"Lost Laboratory of Kwalish\" class=\"tooltip\">[LLK]</span></em></strong>. Пока эта стальная полированная сфера вращается вокруг вашей головы, вы получаете владение навыком История или бонус +1 к проверкам этого навыка, если уже владеете им.</p>&#13;\n</div>&#13;\n<div data-sort=\"element\" data-rarity=\"3\" data-source=\"LLK\">&#13;\n<p><strong><em>Знание природы (редкий) <span title=\"Lost Laboratory of Kwalish\" class=\"tooltip\">[LLK]</span></em></strong>. Пока этот блестящий латунный камень вращается вокруг вашей головы, вы получаете владение навыком Природа или бонус +1 к проверкам этого навыка, если уже владеете им.</p>&#13;\n</div>&#13;\n<div data-sort=\"element\" data-rarity=\"3\" data-source=\"LLK\">&#13;\n<p><strong><em>Знание религии (редкий) <span title=\"Lost Laboratory of Kwalish\" class=\"tooltip\">[LLK]</span></em></strong>. Пока этот крохотный золотистый самоцвет вращается вокруг вашей головы, вы получаете владение навыком Религия или бонус +1 к проверкам этого навыка, если уже владеете им.</p>&#13;\n</div>&#13;\n<div data-sort=\"element\" data-rarity=\"3\" data-source=\"LLK\">&#13;\n<p><strong><em>Знание языков (редкий) <span title=\"Lost Laboratory of Kwalish\" class=\"tooltip\">[LLK]</span></em></strong>. Пока этот пульсирующий осколок красного драгоценного кристалла вращается вокруг вашей головы, вы владеете одним дополнительным языком. Мастер выбирает несомый камнем язык.</p>&#13;\n</div>&#13;\n<div data-sort=\"element\" data-rarity=\"3\" data-source=\"LLK\">&#13;\n<p><strong><em>Самосохранение (редкий) <span title=\"Lost Laboratory of Kwalish\" class=\"tooltip\">[LLK]</span></em></strong>. Пока этот серебристый самоцвет вращается вокруг вашей головы, вы получаете бонус +1 к спасброскам Интеллекта.</p>&#13;\n</div>&#13;\n</div></div>&#13;\n</div>",
		Attunement = false,
		Type = MagicItemType.WondrousItem,
		Rarity = Rarity.Varies
	};
	public static MagicItem magicItemHagEye { get; } = new MagicItem()
	{
        Id = Guid.Parse("B333A401-FD08-46B1-82DD-8C759E5D711D"),
        NameUa = "",
		DescriptionUa = "",
		Consumable = false,
		Charged = false,
		NameRus = "Глаз карги",
		NameEng = "Hag Eye",
		DescriptionUa1 = "<p> Субота може створити магічний об’єкт під назвою око Каргі, який виготовляється з справжнього ока, покритого лаку, підвішеним у манері кулон.\n Зазвичай оку довіряють помічник, для збереження та перенесення.\n Карга в суботі може <em> з дії </em> & nbsp; побачити це око, якщо він з нею в тому ж плані.\n Око Karga KD 10, 1 удари та темне зір в радіусі 60 футів.\n Якщо ви знищуєте його, всі члени суботи отримують шкоду психічній енергії <cin-roller formula = \"3k10\"> 3k10 </bin-roller> психічного пошкодження і стають <dialytooltip type = \"екран\"> <a href = \"/екрани/засліплені\"> засліплений </a> </dumstooltip> протягом 24 годин. </p> <p> Schabash може мати лише одне око одночасно, а створення нового вимагає ритуалу від усіх трьох учасників.\n Ритуал займає 1 годину, і & nbsp; kargs не зможуть виконати його, коли <dial-tooltip type = \"екран\"> <a href=\"/screens/blinded\"> сліпі </a> </demand-tooltip >.\n Якщо під час ритуалу є якась карга, яка виконує зайві дії, субота повинна знову почати & nbsp; ритуал. </p>",
		DescriptionRus1 = "<p>Шабаш может создать магический предмет, называемый глазом карги, который делают из настоящего глаза, покрытого лаком, подвешенного на манер кулона. Обычно глаз доверяют помощнику, для сохранения и переноски. Карга в шабаше может <em>Действием</em>&nbsp;посмотреть через этот глаз, если он находится на одном с ней плане. У глаза карги КД 10, 1 хит и тёмное зрение в радиусе 60 футов. Если его разрушить, все члены шабаша получают урон психической энергией <dice-roller formula=\"3к10\">3к10</dice-roller> психического урона и становятся <detail-tooltip type=\"screen\"><a href=\"/screens/Blinded\">ослеплёнными</a></detail-tooltip> на 24 часа.</p><p>У шабаша может быть только один глаз одновременно, и создание нового требует проведения ритуала всеми тремя участницами. Ритуал занимает 1 час, и&nbsp;карги не смогут совершить его, будучи <detail-tooltip type=\"screen\"><a href=\"/screens/Blinded\">слепыми</a></detail-tooltip>. Если во время совершения ритуала какая-нибудь карга совершает любое лишнее действие, шабаш должен начинать&nbsp;ритуал заново.</p>",
		Source = "Бестиарий",
		Attunement = false,
		Type = MagicItemType.WondrousItem,
		Rarity = Rarity.UnknownRarity
	};
	public static MagicItem magicItemBookOfVileDarkness { get; } = new MagicItem()
	{
		Id = Guid.Parse("A9E8300B-38B5-4103-819A-24E93B78F5AE"),
		NameUa = "",
		DescriptionUa = "",
		Consumable = false,
		Charged = false,
		NameRus = "Книга мерзкой тьмы",
		NameEng = "Book of Vile Darkness",
		DescriptionRus1 = "<p>Содержимое этого отвратительного манускрипта &mdash; лакомый кусочек для тех, кто служит злу. Смертные не должны знать хранящиеся в нём тайны, они настолько ужасны, что один только взгляд на его страницы приводит к <a href=\"/screens/Madness\">безумию</a>.</p><p>Большинство считает, что авторство Книги Мерзкой Тьмы принадлежит богу-личу <a href=\"/gods/Vecna\">Векне</a>. На её страницах он записал все свои больные идеи, все безумные мысли и все примеры самой чёрной магии, известные ему. Векна раскрыл все мерзкие темы, сделав книгу жутким каталогом всех смертных грехов.</p><p>Книга была в руках и других злодеев, и многие дополняли её своими мыслями. Эти дополнения сразу видны, так как они либо вклеивали свои страницы, либо делали пометки на полях и между строк. Есть также места, где страницы вырваны или полностью залиты чернилами или кровью, так что оригинальный текст уже не разобрать. Присутствие книги уничтожает природу. Обычные растения вянут при ней, животные отказываются к ней приближаться, книга постепенно уничтожает всё, к чему прикасается. Даже камень трескается и становится прахом, если книга долго лежит на нём.</p><p>Существо, настроенное на эту книгу, должно потратить 80 часов на чтение и изучение её содержимого, чтобы получить преимущества от неё. После этого существо может изменять содержимое книги, при условии, что эти модификации увеличивают или распространяют зло.</p><p>Если на Книгу Мерзкой Тьмы настраивается не-злое существо, оно совершает спасбросок <span class=\"saving_throw\">Харизмы</span> со Сл 17. При провале его мировоззрение становится нейтрально-злым.</p><p>Книга Мерзкой Тьмы остаётся с вами только пока вы сеете зло в мире. Если вы за 10 дней не совершили ни одного злого поступка, или добровольно совершаете добрый поступок, книга исчезает. Если вы умираете, будучи настроенным на&nbsp;эту книгу, вашу душу забирает сущность великого зла. Вы не можете вернуться к жизни никакими средствами, пока ваша душа похищена.</p><p><strong>Случайные свойства.</strong> Книга Мерзкой Тьмы обладает несколькими свойствами, определяемыми случайным образом:</p><ul><li style=\"text-align: justify;\">3 <detail-tooltip type=\"screen\"><a href=\"/screens/Minor_Beneficial_Properties\">малых положительных свойства</a></detail-tooltip></li><li style=\"text-align: justify;\">1 <detail-tooltip type=\"screen\"><a href=\"/screens/Major_Beneficial_Properties\">основное положительное свойство</a></detail-tooltip></li><li style=\"text-align: justify;\">3 <detail-tooltip type=\"screen\"><a href=\"/screens/Minor_Detrimental_Properties\">малых отрицательных свойства</a></detail-tooltip></li><li style=\"text-align: justify;\">2 <detail-tooltip type=\"screen\"><a href=\"/screens/Major_Detrimental_Properties\">основных отрицательных свойства</a></detail-tooltip></li></ul><p><strong>Изменение характеристик.</strong> После того как вы потратите нужное время на чтение и изучение книги, одна ваша характеристика на ваш выбор&nbsp;увеличивается на 2, с максимумом 24. Другая ваша характеристика на ваш выбор уменьшается на 2, с минимумом 3. Книга не может позже изменить&nbsp;ваши характеристики повторно.</p><p><strong>Метка тьмы.</strong> После того как вы потратите нужное время на чтение и изучение книги, вы получаете физическое уродство, отражающее вашу&nbsp;преданность мерзкой тьме. На вашем лице может появиться руна. Ваши глаза могут стать абсолютно чёрными, или же на лбу могут вырасти рога. Вы можете покрыться морщинами или язвами, можете потерять часть лица, можете получить раздвоенный язык или другую особенность, выбранную Мастером. Метка тьмы позволяет вам совершать с <span class=\"advantage\">преимуществом</span> проверки <strong><em>Харизмы (Убеждение)</em></strong> при взаимодействии со злыми существами, а также проверки <strong><em>Харизмы (Запугивание)</em></strong> при взаимодействии с не-злыми персонажами.</p><p><strong>Командование злом.</strong> Если вы настроены на книгу и держите её в руках, вы можете действием наложить на злую цель заклинание <detail-tooltip type=\"spell\"><a href=\"/spells/Dominate_monster\">подчинение чудовища [dominate monster]</a></detail-tooltip> (Сл спасброска 18). Вы не сможете использовать это свойство повторно до следующего рассвета.</p><p><strong>Тёмные знания.</strong> Вы можете обращаться к Книге Мерзкой Тьмы, если совершаете проверку <strong>Интеллекта</strong> для вспоминания информации о чём-то злом, например, о демонах. Если вы это делаете, то ваш бонус мастерства для этой проверки удваивается.</p><p><strong>Тёмная Речь.</strong> Если вы несёте Книгу Мерзкой Тьмы и настроены на неё, вы можете <em>Действием</em> прочесть вслух текст с её страниц на нечистом языке, известном как Тёмная Речь. Каждый раз, когда вы это делаете, вы получаете урон психической энергией <dice-roller formula=\"1d12\">1к12</dice-roller>, а все не-злые существа в пределах 15 футов от вас получают урон психической энергией <dice-roller formula=\"3d6\">3к6</dice-roller>.</p><p><strong>Уничтожение книги.</strong> Из Книги Мерзкой Тьмы можно вырывать страницы, но зло, содержащееся на них, в конечном счете, возвращается в неё,&nbsp;обычно когда новый автор добавляет туда свои знания. Если солар порвёт книгу на две части, она будет уничтожена на <dice-roller formula=\"1d100\">1к100</dice-roller> лет, после чего формируется заново в тёмной части мультивселенной.</p><p>Существо, настроенное на книгу в течение ста лет, может найти фразу, скрытую среди оригинального текста, которая, если её перевести на Небесный и произнести вслух, уничтожит и книгу и того, кто её произнесёт, в яркой вспышке света. Однако если в мультивселенной остаётся зло, книга формируется заново через <dice-roller formula=\"1d10*100\">1к10 &times; 100</dice-roller> лет. Если всё зло в мультивселенной будет уничтожено, книга будет уничтожена навсегда.</p>",
		DescriptionRus2 = "<div itemprop=\"description\"><p>Содержимое этого отвратительного манускрипта — лакомый кусочек для тех, кто служит злу. Смертные не должны знать хранящиеся в нём тайны, они настолько ужасны, что один только взгляд на его страницы приводит к безумию.</p>&#13;\n<p>Большинство считает, что авторство <em>книги мерзкой тьмы</em> принадлежит богу-личу Векне. На её страницах он записал все свои больные идеи, все безумные мысли и все примеры самой чёрной магии, известные ему. Векна раскрыл все мерзкие темы, сделав книгу жутким каталогом всех смертных грехов.</p>&#13;\n<p>Книга была в руках и других злодеев, и многие дополняли её своими мыслями. Эти дополнения сразу видны, так как они либо вклеивали свои страницы, либо делали пометки на полях и между строк. Есть также места, где страницы вырваны или полностью залиты чернилами или кровью, так что оригинальный текст уже не разобрать.</p>&#13;\n<p>Присутствие книги уничтожает природу. Обычные растения вянут при ней, животные отказываются к ней приближаться, книга постепенно уничтожает всё, к чему прикасается. Даже камень трескается и становится прахом, если книга долго лежит на нём.</p>&#13;\n<p>Существо, настроенное на эту книгу, должно потратить 80 часов на чтение и изучение её содержимого, чтобы получить преимущества от неё. После этого существо может изменять содержимое книги, при условии, что эти модификации увеличивают или распространяют зло.</p>&#13;\n<p>Если на <em>книгу мерзкой тьмы</em> настраивается не-злое существо, оно совершает спасбросок Харизмы Сл 17. При провале его мировоззрение становится нейтрально-злым.</p>&#13;\n<p><em>Книга мерзкой тьмы</em> остаётся с вами только пока вы сеете зло в мире. Если вы за 10 дней не совершили ни одного злого поступка, или добровольно совершаете добрый поступок, книга исчезает. Если вы умираете, будучи настроенным на эту книгу, вашу душу забирает сущность великого зла. Вы не можете вернуться к жизни никакими средствами, пока ваша душа похищена.</p>&#13;\n<p><em><strong><a href=\"/articles/inventory/139-artifacts/\" target=\"_blank\"><strong>Случайные свойства</strong></a>. </strong></em><em>Книга мерзкой тьмы</em> обладает несколькими <a href=\"/articles/mechanics/139-artefakty/\" target=\"_blank\">свойствами</a>, определяемыми случайным образом:</p>&#13;\n<ul>&#13;\n<li>3 малых положительных свойства </li>&#13;\n<li>1 основное положительное свойство </li>&#13;\n<li>3 малых отрицательных свойства </li>&#13;\n<li>2 основных отрицательных свойства </li>&#13;\n</ul>&#13;\n<p><strong><em>Изменение характеристик.</em></strong> После того, как вы потратите нужное время на чтение и изучение книги, одна ваша характеристика на ваш выбор увеличивается на 2 с максимумом 24. Другая ваша характеристика на ваш выбор уменьшается на 2 с минимумом 3. Книга не может позже изменить ваши характеристики повторно.</p>&#13;\n<p><em><strong>Метка тьмы.</strong></em> После того, как вы потратите нужное время на чтение и изучение книги, вы получаете физическое уродство, отражающее вашу преданность мерзкой тьме. На вашем лице может появиться руна. Ваши глаза могут стать абсолютно чёрными, или же на лбу могут вырасти рога. Вы можете покрыться морщинами или язвами, можете потерять часть лица, можете получить раздвоенный язык или другую особенность, выбранную Мастером. Метка тьмы позволяет вам совершать с преимуществом проверки Харизмы (<span tooltip-for=\"skill.persuasion\" title=\"skill.persuasion\">Убеждение</span>) при взаимодействии со злыми существами, а также проверки Харизмы (<span tooltip-for=\"skill.intimidation\" title=\"skill.intimidation\">Запугивание</span>) при взаимодействии с не-злыми персонажами.</p>&#13;\n<p><em><strong>Командование злом.</strong></em> Если вы настроены на книгу и держите её в руках, вы можете действием наложить на злую цель заклинание <a href=\"/spells/241-dominate_monster/\">подчинение чудовища [dominate monster]</a> (Сл спасброска 18). Вы не сможете использовать это свойство повторно до следующего рассвета.</p>&#13;\n<p><strong><em>Тёмные знания.</em></strong> Вы можете обращаться к Книге Мерзкой Тьмы, если совершаете проверку Интеллекта для вспоминания информации о чём то злом, например, о демонах. Если вы это делаете, то ваш бонус мастерства для этой проверки удваивается.</p>&#13;\n<p><em><strong>Тёмная Речь.</strong></em> Если вы несёте Книгу Мерзкой Тьмы и настроены на неё, вы можете действием прочесть вслух текст с её страниц на нечистом языке, известном как Тёмная Речь. Каждый раз, когда вы это делаете, вы получаете 1к12 урона психической энергией, а все не-злые существа в пределах 15 футов от вас получают 3к6 урона психической энергией.</p>&#13;\n<p><strong><em>Уничтожение книги.</em></strong> Из <em>книги мерзкой тьмы</em> можно вырывать страницы, но зло, содержащееся на них, в конечном счете, возвращается в неё, обычно когда новый автор добавляет туда свои знания. Если <a href=\"/bestiary/34-solar/\">солар [solar]</a> порвёт книгу на две части, она будет уничтожена на 1к100 лет, после чего формируется заново в тёмной части мультивселенной.</p>&#13;\n<p>Существо, настроенное на книгу в течение ста лет, может найти фразу, скрытую среди оригинального текста, которая, если её перевести на Небесный и произнести вслух, уничтожит и книгу и того, кто её произнесёт, в яркой вспышке света.</p>&#13;\n<p>Однако если в мультивселенной остаётся зло, книга формируется заново через 1к10×100 лет. Если всё зло в мультивселенной будет уничтожено, книга будет уничтожена навсегда.</p>&#13;\n<br/><div class=\"additionalInfo\"><h3 class=\"smallSectionTitle\"><strong>Мерзкие знания</strong></h3><p><em>Книга мерзкой тьмы</em> описывает всё зло, существующее во Вселенной. Персонаж может найти в ней такие ужасные тайны, что их не должен знать ни один смертный. Среди прочих тем встречаются следующие:</p>&#13;\n<ul>&#13;\n<li><strong>Апофеоз греховности.</strong> Книга может содержать ритуал, позволяющий персонажу стать личем или рыцарем смерти. </li>&#13;\n<li><strong>Истинные имена.</strong> В книге могут быть истинные имена многочисленных исчадий. </li>&#13;\n<li><strong>Тёмная магия.</strong> В книге могут быть ужасные и злые заклинания, созданные или отобранные Мастером. В заклинаниях могут быть проклятья, которые калечат, насылают боль, распространяют болезни или требуют жертвоприношений. </li>&#13;\n</ul>&#13;\n</div>&#13;\n</div>",
		Source = "«Dungeon master's guide»",
		Attunement = false,
		Type = MagicItemType.WondrousItem,
		Rarity = Rarity.Artifact,
		Price = new RecomendedPrice()
		{
			Notes = "невозможно купить",
			MinPrice = 250001
		}
	};
	public static MagicItem magicItemWandOfSecrets { get; } = new MagicItem()
    {
        Id = Guid.Parse("99757A03-3059-487B-BB47-29DFB72F1820"),
        NameUa = "",
        DescriptionUa = "",
        Consumable = false,
        Charged = false,
        NameRus = "Волшебная палочка секретов",
        NameEng = "Wand of Secrets",
        DescriptionUa1 = "4 Потім паличка вібрує і вказує на ту, яка вам найближча. </p> </p>",
        DescriptionUa2 = "<div itemprop = \"опис\"> <p> Ця магічна паличка 3 зарядка.\n Якщо ви тримаєте його, ви можете витратити 1 заряд з дією, і якщо є секретні двері або пастки в межах 30 футів від вас, то паличка вібрує і вказує на той, який вам найближчий. </p> &#13;\n<p> Паличка щоденно відновлює заряд 1K3 на світанку. </p> &#13;\n</div>",
        DescriptionRus1 = "<p>У этой волшебной палочки 3 заряда.</p><p>Если вы держите её, вы можете <em>Действием</em> потратить 1 заряд, и если в пределах 30 футов от вас есть потайные двери или ловушки, то палочка завибрирует и укажет на ту, что находится ближе всего к вам.</p><p>Палочка ежедневно восстанавливает <dice-roller formula=\"1к3\">1к3</dice-roller> заряда на рассвете.</p>",
        DescriptionRus2 = "<div itemprop=\"description\"><p>У этой волшебной палочки 3 заряда. Если вы держите её, вы можете действием потратить 1 заряд, и если в пределах 30 футов от вас есть потайные двери или ловушки, то палочка завибрирует и укажет на ту, что находится ближе всего к вам.</p>&#13;\n<p>Палочка ежедневно восстанавливает 1к3 заряда на рассвете.</p>&#13;\n</div>",
        Source = "«Dungeon master's guide»",
        Attunement = false,
        Type = MagicItemType.Wand,
        Rarity = Rarity.Uncommon,
        Price = new RecomendedPrice(){
			Formula = "(1d6 + 1) * 100",
			MinPrice = 101,
			MaxPrice = 500
		}
    };


	public static IEnumerable<MagicItem> GetMagicItems()
    {
        return new List<MagicItem>(){
            magicItemAdamantineArmor,
            magicItemAlchemyJugBlue,
            magicItemAmmunitionPlus1,
            magicItemArmorPlus3,
            magicItemBootsOftheWinterlands,
            magicItemCloakOfInvisibility,
            magicItemDwarvenPlate,
            magicItemGemOfSeeing,
            magicItemHelmOfTelepathy,
            magicItemMaceOfSmiting,
            magicItemMaceOfTerror,
            magicItemOathbow,
            magicItemPotionOfClimbing,
            magicItemPotionOfFireBreath,
            magicItemPotionOfGaseousForm,
            magicItemPotionOfHealing,
            magicItemRingOfProtection,
            magicItemRingOfWarmth,
            magicItemRodOfRulership,
            magicItemSentinelShield,
            magicItemSpellScroll5thLevel,
            magicItemStaffOfThePython,
            magicItemViciousWeapon,
            magicItemIounStone,
            magicItemHagEye,
            magicItemBookOfVileDarkness,
            magicItemWandOfSecrets,
        };
    }

}
