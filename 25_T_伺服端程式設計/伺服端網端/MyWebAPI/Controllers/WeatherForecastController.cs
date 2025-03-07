using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}


//1     �s�@�ڪ��Ĥ@��Web API(Restful API)

//1.1   �إ�CRUD API Ccontroller 
//1.1.1 �bControllers��Ƨ��W���k����[�J�����
//1.1.2 ��������I��uAPI�v�� �����D����ܡu����Ū��/�g�J�ʧ@��API����v�����U�u�[�J�v�s
//1.1.3 �ɦW�ϥιw�]��ValuesController.cs �Y�i�A���U�u�s�W�v�s
//      ���ڭ̷|�o��@�Ӥw�g���g�n��CRUD�[�c��API Ccontroller��
//      ����Ccontroller�����g����ŦXRest�A�ϥ�Get�BGet/{id}�BPost�BPut�BDelete �i��U���ʧ@��


//1.2   �w��Swagger Tool(�p�G���ݭn����)
//1.2.1 �ϥ�NuGet(�M�צW�٤W���k����޲zNuGet�M��)�w��Swashbuckle.AspNetCore�M��
//1.2.2 �bProgram.cs�����U�αҥ�Swagger
//1.2.3 �w�˧���а��楻�M�������A������
//1.2.4 �b���}�C��Jhttp://localhost:xxxx/swagger/index.html (�䤤xxxx�O�z��port)
//1.2.5 ���դ��A��Swagger
//      ��Swagger�O�Ѥ@�a�sSmartBear�����q�ҵo��A�ݩ�L�v�ϥΪ�OpenAPI�M��A�H�ϥΩ�API�}�o�ɪ����ա�
//      ���H���}�o�h�ϥ�Postman�o�ӳn��i��API���աA�ثeSwagger�����D�y��
//      ���Y�إ߱M�׮ɬ�WebAPI�M�רäĿ�Open API�ASwagger�N�����w�˦b�M�פW��  


//1.3   �ϥ�Swagger Tool�Ӷi��ValuesController API���ާ@����
//1.3.1 �ק�Get Action�����e�ô���
//1.3.2 �i��W�[Action�B�ק虜���f������
//1.3.3 �ק�ValuesController�����Ѥ�����}�ô��� ([Route("api/[controller]")])
//      ��Web API�]���S��UI�A�Q���s�����u��NGet���ʧ@�i����աA�L�k��Post�BPut��Delete���ʧ@�i����ա� 
//      ���٦��@�ӱj�j��API�n��sPostman�A�H�e�٨S��Swagger�ɤj���O��Postman�i����ա�
//      ���]���o�̪��ާ@�ت��O���xSwagger���Ϊk�A�H�QWeb API�b�}�o�ɯ�ϥΥ��Ӷi����ա�

/////////////////////////////////////////////////////////////////////////////
///

//2     �d�ұM�׶}�o�ǳ�

//2.1   �Q�ί����اQ�d�ұM������
//2.1.1 �إ�GoodStore�d�Ҹ�Ʈw
//2.1.2 �NProductPhotos��Ƨ��Τ��t���ɮש�ܱM�פ���wwwroot�U
//2.1.3 �bProgram.cs���[�Japp.UseStaticFiles(); (�]���ڭ̶}���O ��WebAPI�M��)
//2.1.4 �b�s��������J�uhttp://localhost:XXXX/ProductPhotos/A3001.jpg�v(XXXX���z��port)���լO�_��ݨ�Ӥ�


//2.2   �إ߱M�׻P��Ʈw���s�u
//2.2.1 �ϥ�DB First�إ� Model
//2.2.2 �ϥ�NuGet(�M�צW�٤W���k����޲zNuGet�M��)�w�ˤU�C�M��
//      (1) Microsoft.EntityFrameworkCore.SqlServer
//      (2) Microsoft.EntityFrameworkCore.Tools 
//2.2.3 ��M��޲z���D���x(�˵� > ��L���� > �M��޲z���D���x)�U���O
//      Scaffold-DbContext "Data Source=���A����};Database=��Ʈw�W��;TrustServerCertificate=True;User ID=�b��;Password=�K�X" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -NoOnConfiguring  -UseDatabaseNames -NoPluralize -Force
//      �Y���\���ܡA�|�ݨ�Build succeeded.�r���A�æbModels��Ƨ��̬ݨ�GoodStoreContext.cs�BCategory.cs�BProduct.cs����Ʈw�������O��
//2.2.4 �bappsettings.json�ɤ����g�s�u�r��(ConnectionString)
//2.2.5 �bProgram.cs���UDbContext����(GoodStoreContext.cs)�ë��wappsettings.json�����s�u�r��{���X(�o�q�����g�bvar builder�o��᭱)

/////////////////////////////////////////////////////////////////////////////


//3     �s�@��CRUD �� Restful API(Web API)

//3.1   �إ�Category��ƪ� API Ccontroller 
//3.1.1 �bControllers��Ƨ��W���k����[�J�����
//3.1.2 ��������I��uAPI�v�� �����D����ܡu�ϥ�Entity Framework����ʧ@��API����v�����U�u�[�J�v�s
//3.1.3 �b��ܤ�����]�w�p�U
//      �ҫ����O: Category(MyStoreAPI.Models)
//      ��Ƥ��e���O: GoodStoreContext(MyStoreAPI.Models)
//      ����W�٨ϥιw�]�Y�i(CategoriesController)
//      ���U�u�s�W�v�s
//3.1.4 �ק�API�������Ѭ��uapi[controller]�v


//3.2   �إ�Product��ƪ� API Ccontroller 
//3.2.1 �bControllers��Ƨ��W���k����[�J�����
//3.2.2 ��������I��uAPI�v�� �����D����ܡu�ϥ�Entity Framework����ʧ@��API����v�����U�u�[�J�v�s
//3.2.3 �b��ܤ�����]�w�p�U
//      �ҫ����O: Product(MyStoreAPI.Models)
//      ��Ƥ��e���O: GoodStoreContext(MyStoreAPI.Models)
//      ����W�٨ϥιw�]�Y�i(ProductsController)
//      ���U�u�s�W�v�s
//3.2.4 �ק�API�������Ѭ��uapi[controller]�v
//���ϥ�Swagger Tool���O��W����� API�i��ާ@���ա�



//3.3   ��Ʊ����ӷ�
//3.3.1 �HSwagger���լd�ݥثeCategoriesController��ProductsController����ƨӷ�
//3.3.2 �NCategoriesController��ProductsController����Action�ѼƧ��ܸ�Ʊ����ӷ��åHSwagger���դΥ�e���
//����Ʊ����ӷ����[���ܭ��n�A�����t�X��@�����աA�z�LSwagger�[�d�ܤơA�N�ા�D�ϥήɾ���

//���ɥR������
//[FromBody]�GHTTP �ШD���D�餺�e(Body)�j�w��Action���ѼƤW�A�q�`�Ω���oJSON�BXML�Ψ�L�榡����r��ơC
//[FromForm]�G�N�Ӧ�HTTP�ШD�D�骺����Ƹj�w��Action���ѼƤW�A�`�Ω󱵦��Ӧ۪��form���檺��ơA�Ҧp application/x-www-form-urlencoded �� multipart/form-data�C
//[FromQuery]�G�NURL�����ѼƸj�w��Action���ѼƤW�A��A�Ʊ�q URL �����o��ƮɨϥΡC
//[FromHeader]�G�NHTTP�ШD�������Y�ȸj�w��Action���ѼƤW�A�A�X�qRequest Header�����o��ơA�ҦpAuthentication Token�BClient�ݸ�T���C
//[FromRoute]�G�NURL���Ѥ����ѼƸj�w��Action���ѼƤW�A��URL���Y�����O�ʺA���A�ݭn���o�o�Ǹ��ѰѼƮɨϥΡC


/////////////////////////////////////////////////////////////////////////////


//4     �ϥ�Get���o���

//4.1   ���o��ƲM��(ProductsController�̪��Ĥ@��Get Action)
//4.1.1 ���ϥ�Swagger���դ��[�d�ثeProduct����ƨ��o���p
//4.1.2 �ϥ�Include()�P�ɨ��o���p���
//4.1.3 �ϥ�Where()���ܬd�ߪ�����ô���
//4.1.4 �ϥ�OrderBy()�����ƧǤ�k���ܸ�ƱƧǨô���
//4.1.5 �ϥ�Select()����S�w�����ô���
//4.1.6 �ϥ�Swagger���դ��[�d�ثeProduct����ƨ��o���p�A�öi��W�z��������
//���o�̦��@�ǭ��n���[�����������γz�L��@�ӥ[�j�L�H�A�ר��ƪ��������p�S�ʱN�|�v�T��@���覡��
//���o�ʹ`���ѷӮɥi�ϥ�JsonIgnore�ӸѨM��


//4.2   �ϥ�DTO(Data Transfer Object)��ƶǿ骫��
//4.2.1 �إ�DTOs��Ƨ�(�o�ӨB�J�i���ݨD�өw)�ө�m�����ɮ�
//4.2.2 �إ�ProductDTO���O
//4.2.3 ��gProductsController�̪�Get Action
//4.2.4 �ϥ�Swagger����
//���Q�n����S�w���̨嫬����k�N�O�ϥ�DTO�Ӷǿ顰


//4.3   ���o�S�w���(ProductsController�̪��ĤG��Get Action)
//4.3.1 ���ϥ�Swagger���դ��[�d�ثeProduct����ƨ��o���p(�z�ѰѼƤΤ����f)
//4.3.2 �ϥ�Include()�P�ɨ��o���p��ƨèϥ�ProductDTO�Ӷǻ����
//4.3.3 �ϥ�Swagger����
//���o�ʹ`���ѷӮɥi�ϥ�JsonIgnore�ӸѨM��


//4.4   �إ�Product��Ƭd�ߥ\��
//4.4.1 �N����ഫ���{���g����ƨæA����gGet Action(���o�ؼg�k�[�c�~�|�n��)
//4.4.2 �[�J���~���O�j�M
//4.4.3 �[�J���~�W������r�j�M
//4.4.4 �[�J����϶��j��
//4.4.5 �[�J���~�ԭz����r�j�M
//4.4.6 �ϥ�Swagger����(��J������V�h�V�Y�V)
//4.4.7 �Q��Request URL�b�s�����W�������
//���o�ӳ����b���ɷ|�]Linq���g�k���P�y����ƳB�z�������A�����P�����G��
//���ݨ̷�Linq���g���覡�θ�ƪ��P�B�ΫD�P�B���o�A�̨�һݧ��ܼg�k��

//4.4.8 �ק���N��Ƹ��J���s���g�k


//4.5   �P�ɨ��oCategory��Product�@��h�����p���
//4.5.1 ���ϥ�Swagger���դ��[�d�ثeCategory����ƨ��o���p
//4.5.2 �إ�CategoryDTO���O
//4.5.3 ��gCategoriesController�̪��Ĥ@��Get Action
//4.5.4 �ϥ�Include()�P�ɨ��o���p��ƨåHCategoryDTO�ǻ�
//4.5.5 �ϥ�Swagger����
//4.5.6 ��gCategoriesController�̪��ĤG��Get Action
//4.5.7 �ϥ�Include()�P�ɨ��o���p��ƨåHCategoryDTO�ǻ�
//4.5.8 �ϥ�Swagger����


//4.6   �ϥ�SQL�y�k�i��d��
//4.6.1 �s�W�@��Get Action GetProductFormSQL()�ó]�w�����f��[HttpGet("formSQL")]
//4.6.2 ��SQL�y�k���g�P���e�@�˪��\��èϥ�DTO�ǻ����G
//4.6.3 �s�@����r�d��
//4.6.4 �ϥ�Swagger����(�o�̷|�o�Ϳ��~�A�]���ϥΤF�X�֬d��)
//4.6.5 �ק�GoodStoreContext�A�W�[ProductDTO��DbSet�ݩ�
//4.6.6 �N_context.Product.FromSqlRaw(sql).ToListAsync();�אּ_context.ProductDTO.FromSqlRaw(sql).ToListAsync();
//4.6.7 �ϥ�Swagger����(�o�̷|�o��ProductDTO�S���]�wPrimary Key���ҥ~)
//4.6.8 �ק�GoodStoreContext��OnModelCreating()�A�Х�ProductDTO��HasNoKey
//4.6.9 �ϥ�Swagger����
//���ϥ�SQL�y�k�i��d�߬OSQL�Ѥ⪺�ߺD�A���MEF Core�w�g�ϥΤ@�q�ɶ��A���ܦh�}�o�H�����鱡��SQL��
//�����L�ϥ�SQL�ɻݪ`�NSQL Injection�����D�A�ӧڭ̨ϥ�SqlParameter���קKSQL Injection��
//���ϥΰѼƤƬd�߬O���� SQL Injection �����Ĥ覡�A�ϥ�SqlParameter�קKSQ�r�걵�g�k�A�����קKSQL Injection���I��


//4.7   ����DbContext�ק諸�u�ư��k
//4.7.1 �ƻsGoodStoreContext.cs�ç�W��GoodStoreContext2.cs
//4.7.2 �ק����O�B�غc�l�W�٤��~�Ӥ����O
//4.7.3 �u�d�UDTO��DbSet��L��DbSet���ƧR��
//4.7.4 OnModelCreating��k���u�d�UProductDTO��Entity�]�w��L�R��
//4.7.5 �[�Jbase.OnModelCreating(modelBuilder);���~�Ӥ����O�Ҫ���k
//4.7.6 �NGoodStoreContext.cs���PProductDTO�������]�m�R��
//4.7.7 �bProgram�̵��UGoodStoreContext2��Service(���`�N���쥻���U��GoodStoreContext���i�R��)
//4.7.8 �ק�ProductsController�W��Ҫ`�J��GoodStoreContext��GoodStoreContext2
//4.7.9 �ϥ�Swagger����
//���p�G�ڭ̥u�O�����h��F�쥻��Context�A�b�}�o���L�{���p�G�o�ͥ������s����DB First���ʧ@�ɡAContext���e�N�Q���m��
//���]���е��[�Q�Ϊ���ɦV���~�Ӽg�k�O���{���X���u�ʤΦA�Ωʡ�



//4.8   �ϥθ�Ʈw�̪��w�s�{��
//4.8.1 �bGoodStore��Ʈw���إ߹w�s�{�ǡA�{���X�p�U(�o�ӹw�s�{�ǥi�H���ڭ̨ϥ����OID�d�ߨ첣�~���)
//------SQL�y�k------
//use GoodStore
//go
//create proc getProductWithCateName
//	@cateID char(2)='A1'
//as
//begin
//	select p.ProductID, p.ProductName, p.Price, p.Description, p.CateID, c.CateName
//    from Product as p inner join Category as c on p.CateID=c.CateID where p.CateID=@cateID
//end
//------SQL�y�k------
//4.8.2 �bProductsController���إߤ@�ӷs��Get Action
//4.8.3 �]�m�����f��[HttpGet("fromProc/{id}")]�AAction�W�٥i�ۭq�A�èϥ�ProductDTO�Ӷǻ����
//4.8.4 �ϥιw�s�{�Ƕi��d��(�Ѽƪ��ǻ��Шϥ�SqlParameter)
//4.8.5 �ϥ�Swagger����


/////////////////////////////////////////////////////////////////////////////////////////////////////////

//5     �ϥ�Post�s�W���

//�����`�Ψ쪺�T�ظ�ƨӷ��覡[FromBody][FromForm][FromQuery]��
//���Y��ƨӷ����O��¦r��μƭȵ��A�w�]��[FromBody]��

//5.1   �򥻷s�W��Ƥ覡
//5.1.1 ���ϥ�Swagger���դ��[�d�ثeProduct��Category��Post(�`�N�䱵���榡��JSON)
//5.1.2 �ϥ�Swagger�惡�G�Ӹ�ƪ���Ʒs�W����(���ɥi��|��required�����~)
//5.1.3 �ק�Category.cs��Product�ݩʬ��D����
//5.1.4 �ק�Product.cs��Category�ݩʬ��D����
//5.1.5 �ϥ�Swagger�A�i��s�W����(���i���\�s�W�g�J��Ʈw�A���õL�ɮפ��W��)
//���ѩ�ǻ����OJSON�榡��ơA�u�n�������Ҧ��ݩʡA�q�L�ҫ������ҧY�i���\��//
//���Y�O�HJSON�ǻ���Ƥ覡�A�h�e�ݪ��b�ǻ��ɻݥ��ରJSON�榡�A�ߵ�API��//
//�����L�]Product���e�ݪ�椤���W���ɮת��\��A�]���᭱�����A���ק//


//5.2   �s�WProduct��ƥ[�J�W�ǷӤ��\��
//5.2.1 �NProductsController��Post Action�Хܬ�[FromForm]�A�Ϩ�ઽ���ѫe�ݪ�汵�����
//5.2.2 �ϥ�Swagger���լO�_�ॿ�`�s�W(�ثe���|�����~,�L�k���`�s�W)
//5.2.3 �إߤ@��ProductPostDTO��Post�Q��DTO�ǻ����
//5.2.4 �إߤ@�ӷs��Post Action�A�����f�]�w��[HttpPost("PostWithPhoto")]�A�å[�J�W���ɮת��ʧ@(�`�JIWebHostEnvironment)
//(�o�̧ڭ̤��n���Ӫ�Post�R���A�ӬO�s���@�ӥH�Q����)
//5.2.5 �N�W���ɮ׼g���@�ӿW�ߪ���k
//5.2.6 �ϥ�Swagger����
//���p�GBind����Ƽҫ����O���㦳�W���ɮת�����(�pIFormFile)�A�Y�Ϥ��Хܸ�ƨӷ���[FromForm]�A������ۤv�P�_�ǰt��[FromForm]��//


//5.3   �������
//5.3.1 �bProductPostDTO.cs�[�J�ݭn���������Ҿ�(Validator)
//5.3.2 �ϥ�Swagger����
//���b�@�몺���p�U�ڭ̥u�|�b�������(Post�BPut�BDelete)�ɶi�����ҡAŪ����ƫh���|��
//5.3.3 �bProductPostDTO.cs�[�J�ۭq���Ҿ�(�ϥ�ValidationAttribute����)
//5.3.4 �b�ݭn�ϥΦ����Ҿ����ݩʤW�[�J����(�o�̽d�Ҭ�ProductName�ݩ�)
//5.3.5 �ϥ�Swagger����
//5.3.6 �إ�CategoryPostDTO���O
//5.3.7 �bCategoryPostDTO.cs�[�J�ݭn���������Ҿ�(Validator)
//5.3.8 �bCategoryPostDTO.cs�[�J�ۭq���Ҿ�(�ϥ�ValidationAttribute����)
//5.3.9 �b�ݭn�ϥΦ����Ҿ����ݩʤW�[�J����
//5.3.10 �ק�CategoriesController��Post��k�A�Ϩ�ǻ�CategoryPostDTO
//5.3.11 �ק�Post Action �����g�k
//5.3.12 �ϥ�Swagger����


//���{�����g�ܦ��A�ڭ̥i�H�o�{DTO�bWebAPI���ظm���O�۷��n����ƶǿ骫��
//�����D�A��API�D�`��¡A�_�h�z�L�k�קK�ϥ�DTO����
//���]���bAPI�]�p���ɭԡA�ڭ̺ɶq���h�ʨ��Ӫ�Model����A��ƪ��ǿ�ҥ�DTO�Ө��N��
//���YDbContext���󪺳]�p�ݨD�A�ڭ̫h�ϥ��~�Ӫ��覡�Өϵ{���X�O���u�ʡ�


/////////////////////////////////////////////////////////////////////////////
//6     �ϥ�Put�ק���

//6.1   �򥻭ק��Ƥ覡
//6.1.1 ���ϥ�Swagger���դ��[�d�ثeProduct��Category��Put(�`�N�䱵���榡��JSON)
//6.1.2 �ϥ�Swagger�惡�G�Ӹ�ƪ���ƭק����(�o��D�n�O�[��@�U���̪���Ƨe�{)
//6.1.3 �s�WCategoryPutDTO���O
//6.1.4 ��gCategoriesController��Put Action���e
//6.1.5 �ϥ�Swagger����
//6.1.6 �s�WProductPutDTO���O
//6.1.7 ��gProductsController��Put Action���e
//6.1.8 �ϥ�Swagger����


/////////////////////////////////////////////////////////////////////////////
//7     �ϥ�Delete�R�����

//7.1   �򥻧R����Ƥ覡
//7.1.1 ��gProductsController��Delete Action���e�A�[�J�R���Ӥ����\��
//7.1.2 �N�R���Ӥ��\��t�إ�FileDelete()��k
//7.1.3 �ϥ�Swagger����
//7.1.4 �ϥ�Swagger���էR��Category���(�o�̷|�o�͸�ƪ����p������ʭ���)
//7.1.5 �إߥi�R���h����ƪ�Delete Action�A�����f�]��[HttpDelete("ByCatID")]�A��k�W�٥i�ۭq�A�ǤJ���Ѭ����ӫ~���OID
//7.1.6 �ϥ�Swagger����
//7.1.7 �A���ϥ�Swagger���էR��Category���
//���@��n�R������ƪ���ƫe�A�|���R���P�����p���l��ƪ�Ҧ���ơA�H�T�O��Ƥ��|�Q�妸�~�R��


/////////////////////////////////////////////////////////////////////////////

//8     �{���X���c-�ϥΨ̿�`�J(Dependency Injection-DI)

//8.0   �ۭq����������O�{���X���c(���Ψ�DI)
//8.0.1 �s�W�@�ӡuValidationAttributes�v��Ƨ��A�æb��Ƨ����إ�MyValidator.cs�ɮ�
//8.0.2 �N�쥻�g�bProductPostDTO��CategoryPostDTO�����ۭq�������O(ValidationAttributes)�K�iMyValidator.cs�ɮפ�
//8.0.3 �N�����ValidationAttributes���ѩΧR��
//8.0.4 �ϥ�Swagger����


//8.1   ��@Service��DI
//8.1.1 �Ыؤ@��Service��Ƨ�
//8.1.2 �b��Ƨ����إ�SomeService.cs���O�ù�@���e
//8.1.3 �bProgram.cs�̵��USomeService�A��
//8.1.4 �إ�API��� SomeController
//8.1.5 �bSomeController�̪`�JSomeService�A��(�o�̴N�ODI���g�k�A���ϥ� new ����r)
//8.1.6 ���g���Get Action
//8.1.7 �ϥ�Swagger����


//8.2   CategoriesController�{���X���c
//8.2.1 �bService��Ƨ����إ�CategoryService�A�ñNCategoriesController�̪����Get Action�������ӷ~�޿貾�ܦ����g
//      (�]�AItemProduct()��k�@�ֲ��JCategoryService)
//8.2.2 �ƻs�@��CategoriesController�A�ç��ɦW��class�W�r�ﱼ(�o�Ӱʧ@���������i�H�A�u�O�n�O�d�ª��g�k�ѰѦҥ�)
//8.2.3 �bProgram.cs�̵��UCategoryService
//8.2.4 �bCategoriesController�̪`�JCategoryService�A��
//8.2.5 ��gCategoriesController�̪����Get Action�g�k�A�ȯd�U�����޿�
//8.2.6 �ϥ�Swagger����
//8.2.7 �NPost�BPut��Delete���c
//8.2.8 CategoriesController�A���c
//8.2.9 �ϥ�Swagger����



////////////////////////////////////////////////////////////////////////////
//9     �걵�ĤT�誺API�����ۤv��API


//9.1   �걵�ĤT��API(���ҥH�A�~����ƶ}�񥭻O�u�ʪ��{��i�v��Ƭ���)
//����ƻ������}�Ghttps://data.moa.gov.tw/open_detail.aspx?id=QcbUEzN6E6DL
//����Ƥ�����}�Ghttps://data.moa.gov.tw/Service/OpenData/TransService.aspx?UnitId=QcbUEzN6E6DL
//9.1.1 OpenData�[������
//9.1.2 �إ�APIModels��Ƨ���m�ĤT��API����Ƽҫ����O
//9.1.3 �bAPIModels��Ƨ��s�WPetAdoptionData.cs���O��
//9.1.4 �Q�θ�Ƥ�����}�Ҧ^�Ǫ�JSON�榡�إ�PetAdoptionData���O�ݩ�(�ƻs�@����ơ��s�����ܩʶK�W���K�WJSON�������O)
//9.1.5 �إߤ@�Ӫťժ�API Contoller-PetAdoptionController�ó]�w������}
//9.1.6 ���gGet()��k�A�ϥ�HttpClient������o�ĤT��API�����
//9.1.7 �ϥ�Swagger����
//9.1.8 �bGet()��k���[�J�����ΰѼ�
//9.1.9 �ϥ�Swagger����
//9.1.10 �Q�βĤT��API�ҵ����ϥλ������A�t�~���g�ܤ֨�Ӥ��P���d�ߥ\��H�Q����
//9.1.11 �ϥ�Swagger����
//���ڭ̥i�H�F���B�βĤT��API�h�զX�λs�@�X���P���d�ߥ\��(�ڭ̦ۤv�Q�n��)��



//9.2   �{���X���c
//�����F�u�Ƶ{���X�A�ڭ̦b�o�̶i��{���X���c
//9.2.1 �N�����\��g�����
//9.2.2 �NPetAdoptionController����HttpClient����g��DI�覡
//9.2.3 �bProgram.cs�����UHttpClient����
//9.2.4 �bService��Ƨ����إ�PetAdoptionService���O�������o�ĤT��API��ƪ��A��
//9.2.5 ���gPetAdoptionService���e�A�]��HttpClient�`�J�Ψ��o��ƪ�GetDataFromAPI��k
//9.2.6 �bProgram.cs�����UPetAdoptionService����
//9.2.7 �NPetAdoptionService�`�JPetAdoptionController�A�ñN��Ӫ`�J��HttpClient�����{���X����
//9.2.8 ��g�C�@�Ӹ�ƨ��o����k���e
//9.2.9 �ϥ�Swagger����
