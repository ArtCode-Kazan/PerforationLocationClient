using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.IO.MemoryMappedFiles;
using System;
using System.IO;
using System.Windows.Forms;

namespace seisapp
{
    public class FileHeader
    {
        public static int channel_count;
        public static int frequency;
        public static DateTime datetime_start;
        public static double longitude;
        public static double latitude;

        public FileHeader(
            int channel_count,
            int frequency,
            DateTime datetime_start,
            double longitude,
            double latitude
            )
        {
            FileHeader.channel_count = channel_count;
            FileHeader.frequency = frequency;
            FileHeader.datetime_start = datetime_start;
            FileHeader.longitude = longitude;
            FileHeader.latitude = latitude;
        }
    }
    public class BinaryFile_Info
    {
        public static string path;
        public static string format_type;
        public static int frequency;
        public static DateTime time_start;
        public static DateTime time_stop;
        public static double longitude;
        public static double latitude;

        public BinaryFile_Info(
            string path,
            string format_type,
            int frequency,
            DateTime time_start,
            DateTime time_stop,
            double longitude,
            double latitude
            )
        {
            BinaryFile_Info.path = path;
            BinaryFile_Info.format_type = format_type;
            BinaryFile_Info.frequency = frequency;
            BinaryFile_Info.time_start = time_start;
            BinaryFile_Info.time_stop = time_stop;
            BinaryFile_Info.longitude = longitude;
            BinaryFile_Info.latitude = latitude;
        }
        static public string name
        {
            get
            {
                return Path.GetFileName(BinaryFile_Info.path);
            }
        }
        static public object get_short_info
        {
            get
            {
                return (path, format_type, frequency, time_start, time_stop, longitude, latitude);
            }
        }
        static public double duration_in_seconds
        {
            get
            {
                return BinaryFile_Info.time_stop.Subtract(BinaryFile_Info.time_start).TotalSeconds;
            }
        }

        static public string formatted_duration
        {
            get
            {
                int secs = Convert.ToInt32(BinaryFile_Info.duration_in_seconds);
                int days = secs / 24 * 3600;
                int hours = (secs - days * 24 * 3600) / 3600;
                int minutes = (secs - days * 24 * 3600 - hours * 3600) / 60;
                double seconds = BinaryFile_Info.duration_in_seconds - days * 24 * 3600 - hours * 3600 - minutes * 60;
                return Operations.format_duration(days, hours, minutes, seconds);
            }
        }
    }
    public class Operations         
    {
        public static string BAIKAL7_FMT = ".00";
        public static string BAIKAL8_FMT = ".xx";
        public static string SIGMA_FMT = ".bin";

        public static int SIGMA_SECONDS_OFFSET = 2;
        public static string COMPONENTS_ORDER = "ZXY";

        static public dynamic binary_read(string path, string type, int count, int skipping_bytes = 0)
        {
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] data;
            int size = 0;
            size = (int)stream.Length;
            data = new byte[size];
            stream.Read(data, 0, size);
            var memoryStream = new MemoryStream(data);
            memoryStream.Seek(skipping_bytes, SeekOrigin.Begin);
            var reader = new BinaryReader(memoryStream);
            if (type == "uint16")
                return reader.ReadUInt16();
            else if (type == "uint32")
                return reader.ReadUInt32();
            else if (type == "double")
                return reader.ReadDouble();
            else if (type == "long")
                return reader.ReadUInt64();
            else if (type == "string")
                return new string(reader.ReadChars(count));
            else
                return false;
        }
        static public DateTime get_datetime_start_baikal7(ulong time_begin)
        {
            DateTime const_datetime = new DateTime(1980, 1, 1);
            ulong seconds = time_begin / 256000000;
            return const_datetime.AddSeconds(seconds);
        }
        static public object read_baikal7_header(string path)
        {
            int channel_count = binary_read(path, "uint16", 1, 0);
            int frequency = binary_read(path, "uint16", 1, 22);
            ulong time_begin = binary_read(path, "long", 1, 104);
            double longitude = binary_read(path, "double", 1, 80);
            double latitude = binary_read(path, "double", 1, 72);
            DateTime datetime = get_datetime_start_baikal7(time_begin);
            return new FileHeader(channel_count, frequency, datetime, longitude, latitude);
        }
        static public object read_baikal8_header(string path)
        {
            int channel_count = binary_read(path, "uint16", 1, 0);
            int day = binary_read(path, "uint16", 1, 6);
            int month = binary_read(path, "uint16", 1, 8);
            int year = binary_read(path, "uint16", 1, 10);
            double dt = binary_read(path, "double", 1, 48);
            double seconds = binary_read(path, "double", 1, 56);
            double latitude = binary_read(path, "double", 1, 72);
            double longitude = binary_read(path, "double", 1, 80);
            DateTime datetime_start = new DateTime(year, month, day, 0, 0, 1).AddSeconds(seconds);
            int frequency = Convert.ToInt16(1 / dt);
            return new FileHeader(channel_count, frequency, datetime_start, longitude, latitude);
        }
        static public object read_sigma_header(string path)
        {
            DateTime datetime_start = new DateTime(1999, 1, 1);
            double longitude = 0;
            double latitude = 0;
            int channel_count = binary_read(path, "uint16", 1, 12);
            int frequency = binary_read(path, "uint16", 1, 24);
            string latitude_src = binary_read(path, "string", 8, 40);
            string longitude_src = binary_read(path, "string", 9, 48);
            string date_src = Convert.ToString(binary_read(path, "uint32", 1, 60));
            string time_src = Convert.ToString(binary_read(path, "uint32", 1, 64));
            string time_src1 = Convert.ToString(binary_read(path, "uint16", 1, 64));
            time_src = time_src.PadLeft(6, '0');
            int year = 2000 + Convert.ToInt32(date_src.Substring(0, 2));
            int month = Convert.ToInt32(date_src.Substring(2, 2));
            int day = Convert.ToInt32(date_src.Substring(4));
            int hours = Convert.ToInt32(time_src.Substring(0, 2));
            int minutes = Convert.ToInt32(time_src.Substring(2, 2));
            int seconds = Convert.ToInt32(time_src.Substring(4));

            NumberFormatInfo provider = new NumberFormatInfo();
            provider.NumberDecimalSeparator = ".";

            try
            {
                datetime_start = new DateTime(year, month, day, hours, minutes, seconds);
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
            }

            try
            {
                longitude = Math.Round((Convert.ToInt32(longitude_src.Substring(0, 3)) + Convert.ToDouble(longitude_src.Substring(3, 5), provider) / 60), 2);
                latitude = Math.Round((Convert.ToInt32(latitude_src.Substring(0, 2)) + Convert.ToDouble(latitude_src.Substring(2, 4), provider) / 60), 2);
            }
            catch (Exception e)
            {
                MessageBox.Show(Convert.ToString(e));
            }

            return new FileHeader(channel_count, frequency, datetime_start, longitude, latitude);
        }
        public static bool is_binary_file_path(string path)
        {            
            if (File.Exists(path) == true)
            {
                string extension = Path.GetExtension(path);
                if (extension == BAIKAL7_FMT | extension == BAIKAL8_FMT | extension == SIGMA_FMT)
                {
                    return true;
                }
                else { return false; }
            }
            else { return false; }
        }
        static public string format_duration(int days, int hours, int minutes, double seconds)
        {
            string hours_fmt = Convert.ToString(hours).PadLeft(2, '0');
            string minutes_fmt = Convert.ToString(minutes).PadLeft(2, '0');
            string seconds_fmt = Convert.ToString(seconds).PadLeft(6, '0'); //THERE SHOULD BE f'{seconds:.3f}'
            if (days != 0)
            {
                return Convert.ToString(days) + " days " + hours_fmt + ":" + minutes_fmt + ":" + seconds_fmt;
            }
            else
            {
                return hours_fmt + ":" + minutes_fmt + ":" + seconds_fmt;
            }
        }
    }
 
    public class Binary_File
    {                
        public string __path;
        public int __resample_frequency;
        public bool __is_use_avg_values;

        public FileHeader __file_header;
        public bool __is_correct_resample_frequency;
        public string __unique_file_name;
        public DateTime __read_date_time_start;
        public DateTime __read_date_time_stop;

        public Dictionary<string, string> BINARY_FILE_FORMATS
        {
            get
            {
                var indexes = new Dictionary<string, string>()
                    {
                        {"BAIKAL7_FMT", "BAIKAL7_EXTENSION"},
                        {"BAIKAL8_FMT", "BAIKAL8_EXTENSION"},
                        {"SIGMA_FMT", "SIGMA_EXTENSION"}
                    };
                return indexes;
            }
        }
        public Binary_File(string file_path, int resample_frequency = 0, bool is_use_avg_values = false)
        {
            bool is_path_correct = Operations.is_binary_file_path(file_path);
            if (is_path_correct == false) { throw new BadFilePath("Invalid path - {1}", __path); }
            // full file path
            __path = file_path;
            
            // header file data
            __file_header = __get_file_header;

            // boolean-parameter for subtraction average values
            __is_use_avg_values = is_use_avg_values;

            // resample frequency
            if (is_correct_resample_frequency(resample_frequency) == true)
            {
                __resample_frequency = resample_frequency;
            }
            else { throw new InvalidResampleFrequency(); }

            //this.__unique_file_name = this.__create_unique_file_name()

            // date and time for start signal reading
            __read_date_time_start = new DateTime();
            // date and time for end signal reading
            __read_date_time_stop = new DateTime();
        }

        private string path
        {
            get { return __path; }
        }
        private FileHeader file_header
        {
            get { return file_header; }
        }
        private bool is_use_avg_values
        {
            get { return is_use_avg_values; }
        }
        private int origin_frequency
        {
            get { return FileHeader.frequency; }
        }
        private int resample_frequency
        {
            get
            {
                if (__resample_frequency == 0)
                { 
                    __resample_frequency = origin_frequency; 
                }
                return __resample_frequency;
            }
        }
        private string file_extension
        {
            get { return Path.GetExtension(path); }
        }
        private string unique_file_name
        {
            get { return __unique_file_name; }
        }
        private string format_type
        {
            get
            {
                foreach (var file in BINARY_FILE_FORMATS)
                {
                    if (file.Value == file_extension)
                    { return file.Key; }
                }
                return null;
            }
        }
        private DateTime origin_datetime_start
        {
            get { return FileHeader.datetime_start; }
        }
        private int channels_count
        {
            get { return FileHeader.channel_count; }
        }
        private int header_memory_size
        {
            get
            {
                int channel_count = channels_count;
                return 120 + 72 * channel_count;
            }
        }
        private int discrete_amount
        {
            get
            {
                FileInfo file = new FileInfo(__path);                
                long file_size = file.Length;
                int discrete_amount = Convert.ToInt32((file_size - header_memory_size) / (FileHeader.channel_count * 4));
                return discrete_amount;
            }
        }
        private double seconds_duration
        {
            get
            {
                int discrete_count = discrete_amount;
                int freq = origin_frequency;
                int accuracy = Convert.ToInt32(Math.Log10(freq));
                double delta_seconds = Math.Round(Convert.ToDouble(discrete_count / freq), accuracy);
                return delta_seconds;
            }
        }
        public DateTime origin_datetime_stop
        {
            get
            {
                return origin_datetime_start.AddSeconds(seconds_duration);
            }
        }
        public DateTime datetime_start
        {
            get
            {
                if (format_type == "SIGMA_FMT")
                { return origin_datetime_start.AddSeconds(Operations.SIGMA_SECONDS_OFFSET); }
                else
                { return origin_datetime_start.AddSeconds(0); }
            }
        }
        public DateTime datetime_stop
        {
            get
            {
                return datetime_start.AddSeconds(seconds_duration);
            }
        }
        private double longitude
        {
            get { return Math.Round(FileHeader.longitude, 6); }
        }
        private double latitude
        {
            get { return Math.Round(FileHeader.latitude, 6); }
        }
        //WARNING! there are a datetime that need to be ...
        private DateTime read_date_time_start
        {
            get
            {
                if (__read_date_time_start == new DateTime())
                {
                    __read_date_time_start = datetime_start;
                }
                return __read_date_time_start;
            }
            set
            {
                DateTime datetime = new DateTime();
                double dt1 = datetime.Subtract(datetime_start).TotalSeconds;
                double dt2 = datetime_stop.Subtract(datetime).TotalSeconds;
                if (dt1 >= 0 & dt2 > 0)
                { __read_date_time_start = datetime; }
                else
                { throw new InvalidDateTimeValue("Invalid start reading datetime"); }
            }
        }
        //WARNING! there are a datetime that need to be ...
        private DateTime read_date_time_stop
        {
            get
            {
                if (__read_date_time_stop == new DateTime())
                {
                    __read_date_time_stop = datetime_start;
                }
                return __read_date_time_stop;
            }
            set
            {
                DateTime datetime = new DateTime();
                double dt1 = datetime.Subtract(datetime_start).TotalSeconds;
                double dt2 = datetime_stop.Subtract(datetime).TotalSeconds;
                if (dt1 > 0 & dt2 >= 0)
                { __read_date_time_stop = datetime; }
                else
                { throw new InvalidDateTimeValue("Invalid stop reading datetime"); }
            }
        }
        private int start_moment
        {
            get
            {
                TimeSpan dt_diff = read_date_time_start.Subtract(datetime_start);
                double dt_seconds = dt_diff.TotalSeconds;
                return Convert.ToInt32(Math.Round(dt_seconds * origin_frequency));
            }
        }
        private int end_moment
        {
            get
            {
                double dt = read_date_time_stop.Subtract(datetime_start).TotalSeconds;
                int discreet_index = Convert.ToInt32(Math.Round(dt * origin_frequency));
                int signal_length = discreet_index - start_moment;
                signal_length = signal_length - (signal_length % resample_parameter);
                discreet_index = start_moment + signal_length;
                return discreet_index;
            }
        }
        //THERE MAY BE A PROBLEM WITH TYPE ADDUCTION
        private int resample_parameter
        {
            get
            {
                double division = origin_frequency / resample_frequency;
                return Convert.ToInt32(Math.Floor(division));
            }
        }        
        private string record_type
        {
            get
            {
                return Operations.COMPONENTS_ORDER;
            }
        }
        public Dictionary<string, int> components_index
        {
            get
            {
                var indexes = new Dictionary<string, int>()
                    {
                        {record_type.Substring(0,1), 1},
                        {record_type.Substring(1,1), 2},
                        {record_type.Substring(2,1), 3}
                    };
                return indexes;
            }
        }
        public object short_file_info
        {
            get
            {
                return BinaryFile_Info.get_short_info;
            }
        }
        public dynamic __get_file_header
        {
            get
            {
                string extension = Path.GetExtension(__path);
                if (extension == Operations.BAIKAL7_FMT)
                {
                    return Operations.read_baikal7_header(__path);
                }
                else if (extension == Operations.BAIKAL8_FMT)
                {
                    return Operations.read_baikal8_header(__path);
                }
                else if (extension == Operations.SIGMA_FMT)
                {
                    return Operations.read_sigma_header(__path);
                }
                else
                    return null;
            }
        }
        public bool is_correct_resample_frequency(int value)
        {
            if (value < 0) { return false; }
            else if (value == 0) { return true; }
            else
            {
                if (origin_frequency % value == 0) { return true; }
                else { return false; }
            }
        }

        //def __create_unique_file_name(self) -> str:
        //return '{}.{}'.format(uuid.uuid4().hex, self.file_extension)

        public dynamic _get_component_signal(string component_name = "Z")
        {
            int column_index;
            if (channels_count == 3)
            {
                components_index.TryGetValue(component_name, out column_index);
            }
            else
            {
                components_index.TryGetValue(component_name, out column_index);
                column_index = column_index + 3;
            }
            int skip_data_size = 4 * channels_count * start_moment;
            int offset_size = header_memory_size + skip_data_size + column_index * 4;
            int strides_size = 4 * channels_count;
            int signal_size = end_moment - start_moment;


            //signal_array = np.ndarray(signal_size, buffer = mm, dtype = np.int32, offset = offset_size, strides = strides_size).copy()

            ;
            FileStream f = new FileStream(path, FileMode.Open, FileAccess.Read);
            MemoryMappedFile mm = MemoryMappedFile.CreateFromFile(
                fileStream: f,
                mapName: "mn",
                capacity: 0,
                access: MemoryMappedFileAccess.Read,
                inheritability: HandleInheritability.None,
                leaveOpen: false
                );




            return null;
        }

        public dynamic read_signal(string component = "Z")
        {
            component = component.ToUpper();
            if (components_index.ContainsKey(component) == false)
            {
                throw new InvalidComponentName("{1} not found", component);
            }
            return null;
        }
    }    
    
    [Serializable]
    internal class InvalidDateTimeValue : Exception
    {
        public InvalidDateTimeValue()
        {
        }

        public InvalidDateTimeValue(string message) : base(message)
        {
        }

        public InvalidDateTimeValue(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidDateTimeValue(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class InvalidResampleFrequency : Exception
    {
        public InvalidResampleFrequency()
        {
        }

        public InvalidResampleFrequency(string message) : base(message)
        {
        }

        public InvalidResampleFrequency(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidResampleFrequency(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class BadFilePath : Exception
    {
        private string v;
        private string file_path;

        public BadFilePath()
        {
        }

        public BadFilePath(string message) : base(message)
        {
        }

        public BadFilePath(string v, string file_path)
        {
            this.v = v;
            this.file_path = file_path;
        }

        public BadFilePath(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BadFilePath(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class InvalidComponentName : Exception
    {
        private string v;
        private string component;

        public InvalidComponentName()
        {
        }

        public InvalidComponentName(string message) : base(message)
        {
        }

        public InvalidComponentName(string v, string component)
        {
            this.v = v;
            this.component = component;
        }

        public InvalidComponentName(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidComponentName(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

