using Autofac;

using DataParser.Client;
using DataParser.Device;
using DataParser.MongoDbStorage;

using System.Text;

const string filePath = "File.txt";
const string connectionString = "mongodb://root:pass12345@localhost:27017";

string fileContent = @"Image Title=""Spaghetti"";Content=""h4i3p2kn43on34no34in34ni6j56i4j7j57o45j5l23l3l5j2lj636l34j6"";

Note Title=""Eat"";Body=""Try Eat Something"";

Note Title=""Write a note"";Body=""Custom not description"";

Note Title=""Read all text"";Body=""Read all notes"";

Image Title=""Bread"";Content=""h4i3p328h09igo23hvo9jw9340vijv48303hbrj84jg9vj4iv43b34ib43jb0934jg436l34j6"";

Image Title=""Eggs"";Content=""h4i3p2kn43on34no34in34ni6j56i4j7onbe9wpogjj84j09vkmv32iu4b39jv2ova8ugl4hvkk84gbjleb349jbn349b4j3b8943bier8943bhefuidbhr9pegjl43hj57o45j5l23l3l5j2lj636l34j6"";

";

File.WriteAllText(filePath, fileContent, Encoding.UTF8);

var builder = new ContainerBuilder();
builder.RegisterType<DataReaderDeviceClient>().As<IDataReaderDeviceClient>();
builder.RegisterType<ConsoleLogger>().As<ILogger>().SingleInstance();
builder.RegisterType<DataReaderDevice>().As<IDataReaderDevice>();
builder.RegisterTypes(typeof(ImageParser), typeof(NoteParser)).As<ParseHandler>();

builder.RegisterType<ConsoleSaveStrategy>().As<IDataSaveStrategy>().Named<IDataSaveStrategy>("console");
builder.RegisterType<MongoDbSaveStrategy>().As<IDataSaveStrategy>().Named<IDataSaveStrategy>("mongo");

builder.RegisterType<MongoDbConnection>().WithParameter("connectionString", connectionString);
builder.RegisterTypes(typeof(ImageSaveOperation), typeof(NoteSaveOperation)).As<SaveOperation>();

var container = builder.Build();


IDataReaderDeviceClient deviceMonitor = container.Resolve<IDataReaderDeviceClient>();

deviceMonitor.DataSaveStrategy = container.ResolveNamed<IDataSaveStrategy>("mongo");

var device = container.Resolve<IDataReaderDevice>();
deviceMonitor.ConnectDevice(device);
deviceMonitor.StartReadFile(device, filePath);