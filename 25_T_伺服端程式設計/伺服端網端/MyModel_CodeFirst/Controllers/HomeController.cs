using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyModel_CodeFirst.Models;
using System.Diagnostics;
using System.IO;

namespace MyModel_CodeFirst.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GuestBookContext _context;
        
        public HomeController(ILogger<HomeController> logger, GuestBookContext context)
        {
            _logger = logger;
            _context = context;
 
        }

        public async Task<IActionResult> Index()
        {
            //3.1.2  �bHomeController���[�JŪ��Book��ƪ��{��
            var photos = await _context.Book.Where(b => b.Photo != null).OrderByDescending(b => b.TimeStamp).Take(5).ToListAsync();
            return View(photos);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}


//MyModel_CodeFirst�M�׶i��B�J

//1. �ϥ�Code First�إ�Model�θ�Ʈw

//1.1   �bModels��Ƨ��̫إ�Book��ReBook������O�����ҫ�
//1.1.1 �bModels��Ƨ��W���k����[�J�����O�A�ɦW���W��Book.cs�A���U�u�s�W�v�s
//1.1.2 �]�pBook���O���U�ݩʡA�]�A�W�١B��������Ψ���������ҳW�h����ܦW��(Display)
//1.1.3 �bModels��Ƨ��W���k����[�J�����O�A�ɦW���W��ReBook.cs�A���U�u�s�W�v�s
//1.1.4 �]�pReBook���O���U�ݩʡA�]�A�W�١B��������Ψ���������ҳW�h����ܦW��(Display)
//1.1.5 ���g������O�������p�ݩʰ������Ӹ�ƪ��������p


//1.2   �إ�DbContext���O
//      ���w�ˤU�C��ӮM��
//      (1)Microsoft.EntityFrameworkCore.SqlServer
//      (2)Microsoft.EntityFrameworkCore.Tools
//      ���PDB First�w�˪��M��@�ˡ�
//1.2.1 �bModels��Ƨ��W���k����[�J�����O�A�ɦW���W��GuestBookContext.cs�A���U�u�s�W�v�s
//1.2.2 ���gGuestBookContext���O�����e
//      (1)���~��DbContext���O
//      (2)���g�̿�`�J�Ϊ��غc�l
//      (3)�y�z��Ʈw�̭�����ƪ�
//1.2.3 �bappsettings.json�����g��Ʈw�s�u�r��
//1.2.4 �bProgram.cs���H�̿�`�J���g�k���UŪ���s�u�r�ꪺ�A��(food panda�BUber Eats)
//      ���`�N�{������m�����n�bvar builder = WebApplication.CreateBuilder(args);�o�y����
//1.2.5 �b�M��޲z���D���x(�˵� > ��L���� > �M��޲z���D���x)�U���O
//      �������`�N�`�N������ �Х��T�w�M�׬O�_���T
//      �������`�N�`�N������ �Х��T�w�M�׬O�_���T
//      �������`�N�`�N������ �Х��T�w�M�׬O�_���T
//      (1)Add-Migration InitialCreate
//      (2)Update-database
//      ����(1)�����uInitialCreate���O�ۭq���W�١A�Y���榨�\�|�ݨ�uBuild succeeded.�v��
//      ���t�~�|�ݨ�@��Migrations����Ƨ��Ψ��ɮ׳Q�إߦb�M�פ��A�̭�������Migration�����{��
//      ����(1)�����O���榨�\�~������(2)�����O��
//      (3)��SSMS���d�ݬO�_�����\�إ߸�Ʈw�θ�ƪ�(�ثe��ƪ��S�����)



//1.3   �Ы�Initializer����إߪ�l(�ؤl)���(Seed Data)
//      �������ڭ̥i�H�b�Ыظ�Ʈw�ɴN�ЫشX����l����Ʀb�̭��H�Ѷ}�o�ɴ��դ��Ρ�����
//      �������Х��N��Ʈw�R���A�ñN�M�פ�Migrations��Ƨ��Τ��t�ɮ׾�ӧR��������

//1.3.1 �ǳƺؤl�Ӥ�(SeedPhotos��Ƨ�)
//1.3.2 �bModels��Ƨ��W���k����[�J�����O�A�ɦW���W��SeedData.cs�A���U�u�s�W�v�s
//1.3.3 ���gSeedData���O�����e
//      (1)���g�R�A��k Initialize(IServiceProvider serviceProvider)
//      (2)���gBook��ReBook��ƪ�����l��Ƶ{��
//      (3)���g�W�ǹϤ����{��
//      (4)�[�W using() �� �P�_��Ʈw�O�_����ƪ��{��
//1.3.4 �bProgram.cs���g�ҥ�Initializer���{��(�n�g�bvar app = builder.Build();����)
//      ���o��Initializer���@�άO�إߤ@�Ǫ�l��Ʀb��Ʈw���H�Q���աA�ҥH���@�w�n��Initializer��
//      ���`�N:��l��ƪ��Ӥ���bBookPhotos��Ƨ�����
//1.3.5 �ظm�M�סA�T�w�M�ק����ظm���\
//1.3.6 �A����M��޲z���D���x(�˵� > ��L���� > �M��޲z���D���x)�U���O
//      (1)Add-Migration InitialCreate
//      (2)Update-database
//1.3.7 ��SSMS���d�ݬO�_�����\�إ߸�Ʈw�θ�ƪ�(�ثe��ƪ��S�����)
//1.3.8 �b�s�����W������������H�إߪ�l���(�Y�S������L�����A��l��Ƥ��|�Q�إ�)
//1.3.9 �A����SSMS���d�ݸ�ƪ��O�_�����


//2.   �s�@�d���O�e�x�\��

//2.1   �s�@�۰ʥͦ���Book��ƪ�CRUD
//2.1.1 �bControllers��Ƨ��W���k����[�J�����
//2.1.2 ��ܡu�ϥ�EntityFramework�����˵���MVC����v�����U�u�[�J�v�s
//2.1.3 �b��ܤ�����]�w�p�U
//      �ҫ����O: Book(MyModel_CodeFirst.Models)
//      ��Ƥ��e���O: GuestBookContext(MyModel_CodeFirst.Models)
//      �Ŀ� �����˵�
//      �Ŀ� �Ѧҫ��O�X�{���w
//      �Ŀ� �ϥΪ����t�m��
//      ����W�٧אּPostBooksController
//      ���U�u�s�W�v�s
//2.1.4 �ק�PostBooksController�A����Edit�BDelete Action
//2.1.5 �R��Edit�BDelete View�ɮ�
//2.1.6 �ק�Index Action���g�k


//2.2   ��ܥ\��
//2.2.1 �ק�A�X�e�x�e�{��Index View
//2.2.2 �NPostBooksController��Details Action��W��Display(View�]�n��W�r)
//2.2.3 �bIndex View���[�JDisplay Action���W�쵲
//2.2.4 �ק�Display View �ƪ��˦��A�ƪ��i�H�ӤH�ߦn�e�{
//      ���ƪ��i�H�ӤH�ߦn�e�{��


//2.3   �ϥΡuViewComponent�v�ޥ���@�u�N�^�Яd�����e��ܩ�Display View�v
//      �����椸�N�n����ViewComponent���ϥΤ覡��
//2.3.1 �b�M�פ��s�WViewComponents��Ƨ�(�M�פW���k����[�J���s�W��Ƨ�)�H��m�Ҧ���ViewComponent������
//2.3.2 �bViewComponents��Ƨ����إ�VCReBooks ViewComponent(�k����[�J�����O����J�ɦW���s�W)
//2.3.3 VCReBooks class�~��ViewComponent(�`�Nusing Microsoft.AspNetCore.Mvc;)
//2.3.4 ���gInvokeAsync()��k���o�^�Яd�����
//2.3.5 �b/Views/Shared�̫إ�Components��Ƨ��A�æbComponents��Ƨ����إ�VCReBooks��Ƨ�
//2.3.6 �b/Views/Shared/Components/VCReBooks�̫إ��˵�(�k����[�J���˵�����ܡuRazor�˵��v�����U�u�[�J�v�s)
//2.3.7 �b��ܤ�����]�w�p�U
//      �˵��W��: Default
//      �d��:Empty(�S���ҫ�)
//      ���Ŀ� �إߦ������˵�
//      ���Ŀ� �ϥΪ����t�m��
//   ���`�N�G��Ƨ���View���W�٤��O�ۭq���A�ӬO���w�]���W�١A�W�w�p�U�G��
//   /Views/Shared/Components/{ComponentName}/Default.cshtml
//   /Views/{ControllerName}/Components/{ComponentName}/Default.cshtml
//2.3.8 �bDefault View�W��[�J@model IEnumerable<MyModel_CodeFirst.Models.ReBook>
//2.3.9 �̳ߦn�s��Default View�ƪ��覡
//2.3.10 �s�gDisplay View�A�[�JVCReBooks ViewComponent
//2.3.11 ����


//2.4   �d���\��
//2.4.1 �ק�Create View�A�ק�W���ɮת�����
//2.4.2 �ק�Create View�A�N<form>�W�[ enctype="multipart/form-data" �ݩ�
//2.4.3 �[�J�e�ݮĪG�A�ϷӤ��i���w��
//2.4.4 �R��ImageType���
//2.4.5 �R��TimeStamp���
//2.4.6 �ק�Post Create Action�A�[�W�B�z�W�ǷӤ����\��
//2.4.7 ���կd���\��
//2.4.8 �bIndex View���[�J���W�ǷӤ����d������ܤ覡
//2.4.9 �bDisplay View���[�J���W�ǷӤ����d������ܤ覡
//2.4.10 �bIndex View���[�J�B�z�u�����檺�d���v��ܤ覡
//2.4.11 �bDisplay View���[�J�B�z�u�����檺�d���v��ܤ覡
//2.4.12 �bVCReBook View Component��Default View���[�J�S���^�Яd���Y����ܪ��P�_



//2.5   �^�Яd���\��
//2.5.1 �bControllers��Ƨ��W���k����[�J�����
//2.5.2 ��ܡu�ϥ�EntityFramework�����˵���MVC����v�����U�u�[�J�v�s
//2.5.3 �b��ܤ�����]�w�p�U
//      �ҫ����O: ReBook(MyModel_CodeFirst.Models)
//      ��Ƥ��e���O: GuestBookContext(MyModel_CodeFirst.Models)
//      �Ŀ� �����˵�
//      �Ŀ� �Ѧҫ��O�X�{���w
//      ���Ŀ� �ϥΪ����t�m��
//      ����W�٧אּRePostBooksController
//      ���U�u�s�W�v�s
//2.5.4 �ק�RePostBooksController�A�ȫO�dCreate Action�A�䥦�����R��
//2.5.5 �ȫO�dCreate View�ɮסA�䥦�����R��
//2.5.6 �ק� Create View
//      ���s�@�e��ݤ������^�Яd���\�ࡰ

//2.5.7 �bPostBooks\Display View���NRePostBooks\Create View�HAjax�覡Ū�J
//2.5.8 �t�XBoostrap Modal Component��ܥXCreate�e��
//2.5.9 �ǻ�BookID�Ѽ�
//2.5.10 �NReBooks\Create View��<form>�[�WBookID���������
//2.5.11 ���ծĪG
//2.5.12 �ק�ReBooksController����Create Action�A�Ϩ�Return JSON���
//2.5.13 �bPostBooks\Display View�����g������JavaScript�{���A�HAjax�覡����s�W�^�Яd��
//2.5.14 �NReBooks\Create View��Form�إ�ID
//2.5.15 �bReBooksController�����g��VCRebook ViewComponent���o�^�Яd����ƪ�Action
//2.5.16 ���ծĪG

//----------------------------------�o���u�H�W�O���q�d��-----------------------------------------------

//3     �����]�λP�G��
//3.1   Bootstrap����-�Q��Bootstrap�̪��\��@�����Ӥ�����
//3.1.1 �bHome/Index View���ϥ�Bootstrap��Carousel����
//3.1.2 �bHomeController���[�JŪ��Book��ƪ��{��
//3.1.3 �s��Home/Index View��{�Ӥ������ĪG 

//3.2   �G���]�p
//3.2.1 �bShared��Ƨ����إ�_UserLayout.cshtml�G����
//3.2.2 �bShared��Ƨ����إ�_Layout.cshtml�G����
//3.2.3 �]�wHome/Index View��Layout��_UserLayout
//3.2.4 �إ�VCBooksTopThree.cs �� ViewComponent
//3.2.5 ���gVCBooksTopThree Class�Ϩ��Ū�X�̷s�T���d��
//3.2.6 �bShared/Components��Ƨ����إ�VCBooksTopThree��Ƨ��A�æb�䤤�إ�Default.cshtml��
//3.2.7 ���gVCBooksTopThree��Default View�A�Ϩ����̷ܳs�T���d��
//3.2.8 �bHome/Index View���[�JVCBooksTopThree ViewComponent

//3.3   Layout���B�z
//3.3.1 �NViewstart.cshtml����Layout�]�w��_UserLayout
//3.3.2 �ק�_UserLayout����椺�e�Χe�{�覡


//4.    �s�@�d���O��x�޲z�\��

//4.1   �s�@�۰ʥͦ���Book��ƪ�CRUD
//4.1.1 �bControllers��Ƨ��W���k����[�J�����
//4.1.2 ��ܡu�ϥ�EntityFramework�����˵���MVC����v�����U�u�[�J�v�s
//4.1.3 �b��ܤ�����]�w�p�U
//      �ҫ����O: Book(MyModel_CodeFirst.Models)
//      ��Ƥ��e���O: GuestBookContext(MyModel_CodeFirst.Models)
//      �Ŀ� �����˵�
//      �Ŀ� �Ѧҫ��O�X�{���w
//      �Ŀ� �ϥΪ����t�m��
//      ����W�٨ϥ�(BooksManageController)
//      ���U�u�s�W�v�s
//4.1.4 ����/BooksManage/Index �i�����
//4.1.5 �ק�Index View�NPhoto��ImageType���BCreate�BEdit��Details�W�쵲����
//4.1.6 �̳ߦn�ۦ�ק虜��


//4.2   �վ�BooksManageController���e 
//4.2.1 ��gIndex Action�����e�A�N�d���̷s���±Ƨ�
//4.2.2 ����Details Action (��i�@�֧R�� Details.cshtml)
//4.2.3 ����Create Action (��i�@�֧R�� Create.cshtml)
//4.2.4 ����Edit Action (��i�@�֧R�� Edit.cshtml)
//4.2.5 �R��Delete.cshtml


//4.3   �bIndex View�e�{�^�Яd�����
//4.3.1 �bIndex View���[�J�e�{�^�Яd����ViewComponent
//4.3.2 �s�W�@��VCRebooks/Delete.cshtml View
//4.3.3 �NDelete View���s�ƪ��å[�J�R���^�Яd�������s
//4.3.4 �bVCRebooks ViewComponent���[�JisDel�ѼƧP�_�O�_�e�{Delete View
//4.3.5 �bIndex View���e�{�^�Яd����ViewComponent�W�[isDel�Ѽƪ��ǻ�
//4.3.6 �ϥ�Bootstrap��Collapse Component�ӧe�{�d�����
//4.3.7 �N�e�{�^�Яd����id�אּ�ʺA����
//4.3.8 ���յe���ĪG



//4.4   �s�@�R���d���\��
//4.4.1 �bBooksManageController����Delete Action�[�J�R���Ϥ����{��
//4.4.2 �NBooksManage/Index View���R�����s��g�����ǰe
//4.4.3 ���էR���d���\��
//      ���o�̩һs�@���R���|�N�����p���^�Яd����Ƥ@�֧R����
//4.4.4 �bBooksManageController�[�H����DeleteReBook Action
//4.4.5 �NVCRebooks/Delete View���R���s�s�@�HAjax�覡�R���H�O�d�������㭶��s
//4.4.6 ���gAjax�{���H�I�sDeleteReBook Action
//4.4.7 �bBooksManageController���[�JGetRebookByViewComponent Action
//4.4.8 �Q��GetRebookByViewComponent Action������s�e���H��ܧR���᪺�^�Яd����Ƶe��
//4.4.9 ���էR���d���\��
//      ���o�̩һs�@���R���|�N�����p���^�Яd����Ƥ@�֧R����



//5   �n�J�\��s�@

//5.1   ��Ʈw�ܧ�
//5.1.1 ��Code-First�覡�b��Ʈw�̷s�W�@��Login��ƪ�s��޲z�̱b���K�X
//5.1.2 �bModels��Ƨ��̫إ�Login���O�����ҫ�
//5.1.3 Models��Ƨ��W���k����[�J�����O�A�ɦW���W��Login.cs�A���U�u�s�W�v�s
//5.1.4 �]�pLogin���O���U�ݩʡA�]�A�W�١B��������Ψ���������ҳW�h����ܦW��(DisplayName)
//5.1.5 �ק�GuestBookContext���O�����e�A�[�J�y�z��Ʈw��Login����ƪ�
//5.1.6 �b�M��޲z���D���x(�˵� > ��L���� > �M��޲z���D���x)�U���O
//      �������`�N�`�N������ �Х��T�w�M�׬O�_���T
//      �������`�N�`�N������ �Х��T�w�M�׬O�_���T
//      �������`�N�`�N������ �Х��T�w�M�׬O�_���T
//      (1)Add-Migration AddLoginTable
//      (2)Update-database
//5.1.7 ��SSMS���d�ݬO�_�����\�إ�Login��ƪ�
//5.1.8 �bLogin��ƪ��إߤ@���b���K�X�����(admin, 12345678)



//5.2   �s�@Login�\��P�e��
//5.2.1 �bControllers��Ƨ��W���k����[�J�����
//5.2.2 ��ܡuMVC���-�ťաv�����U�u�[�J�v�s
//5.2.3 �ɦW���W���uLoginController�v�����U�u�s�W�v�s
//5.2.4 �إ�Get�PPost��Login Action
//5.2.5 �إ�Login View(Login Action�����k����s�W�˵���Razor�˵������U�u�[�J�v�s)
//      �b��ܤ�����]�w�p�U
//      �˵���: Login (�ϥιw�]�W��)
//      �d��: Create
//      �ҫ����O: Login(MyModel_CodeFirst.Models)
//      ��Ƥ��e���O: GuestBookContext(MyModel_CodeFirst.Models)
//      ���Ŀ� �إߦ������˵�
//      �Ŀ� �Ѧҫ��O�X�{���w
//      �Ŀ� �ϥΪ����t�m��
//5.2.6 �NViewData["Error"]�[�JLogin View
//5.2.7 ����


//�������`�N�`�N������
//�����ɪ��n�J�P�D�n�J���p�ڥ��S���Q�����A�Y�ϨS���n�J�A���ઽ���Hurl�i�J��x�޲z������
//���]���ڭ̥����N���n�J�L���ϥΪ̬����U�ӡA�p�G�S���n�J�������ϥΪ̧Y�ϳz�Lurl�]�i���h��x�޲z������


//5.3   �إ߶i�J��x�����O�n�J���A��@
//5.3.1 �b_ViewStart.cshtml���[�J�e�x�Ϋ�x�ϥΤ��PLayout���P�_��
//5.3.2 �b_UserLayout.cshtml���[�J�n�J��x�����s
//5.3.3 �bProgram.cs�����U�αҥ�Session
//5.3.4 �bLoginController��Post Login Action���[�JSession�����n�J���A
//5.3.5 �b_ViewStart.cshtml�[�J���n�J�h�N�����۰ʾɩ�/Home/Index���P�_��
//5.3.6 ����


//5.4   �n�X�\��
//5.4.1 �bLoginController�[�JLogout Action
//5.4.2 �b_Layout.cshtml��_UserLayout.cshtml�[�J�n�X�����s
//5.4.3 ����
//�������o�̥i�H�յ۰��X�b���޲z���\��A��Login��ƪ�i��s�W�B�R��������



//6     �򥻪����~�B�z(Error Handle)
//6.1   ����:�G�N���{���o�ͨҥ~�ݬݵ��G
//6.1.1 �bPostBooksController�̼g�@�ӷ|�o�ͨҥ~��Action�p�U
//public IActionResult ExceptionTest()
//{
//    int a = 0;
//    int s = 100 / a;
//    return View();
//}
//6.1.2 �Q�έ쥻�w�]��Home Controller Error Handler�ӳB�z�ҥ~
//6.1.3 �ק� Program.cs�����{���X�A�N�O�_�b�}�o�Ҧ��U�����~�B�z�P�_���ѱ�
//6.1.4 ����:�A���G�N���{���o�ͨҥ~�ݬݵ��G
//6.1.5 �ק�Error.cshtml���e
//6.2   ����:�G�N���{���o��HttpNotFound(404)���~
//6.2.1 �bProgram.cs�����{���X���U�B�zHttpNotFound(404)���~��Error Handler
//6.2.2 ����:�A���G�N���{���o��HttpNotFound(404)���~
//      ���̰򥻪����~�B�z�A�N�O�����ϥΪ̬ݨ�t�ο��~�T����





