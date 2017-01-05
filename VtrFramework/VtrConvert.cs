using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using VtrFramework.Extensions;


namespace VtrFramework
{
    public static class VtrConvert
    {

        #region PROPRIEDADES PÚBLICAS ESTÁTICAS - FORMATOS PADRÃO 

        /// <summary>
        /// retorna o formato padrão de inteiros
        /// </summary>
        /// <returns></returns>
        public static string DEFAULT_INTEGER_FORMAT
        {
            get
            {
                return VtrConvert.GET_DEFAULT_INTEGER_FORMAT();
            }
        }


        /// <summary>
        /// retorna o formato padrão de decimais
        /// </summary>
        /// <returns></returns>
        public static string DEFAULT_FLOAT_FORMAT
        {
            get
            {
                return VtrConvert.GET_DEFAULT_FLOAT_FORMAT();
            }
        }

        /// <summary>
        /// retorna o formato padrão de datas
        /// </summary>
        /// <returns></returns>
        public static string DEFAULT_DATE_FORMAT
        {
            get
            {
                return VtrConvert.GET_DEFAULT_DATE_FORMAT();
            }
        }

        /// <summary>
        /// retorna o formato padrão de data/hora
        /// </summary>
        /// <returns></returns>
        public static string DEFAULT_DATETIME_FORMAT
        {
            get
            {
                return VtrConvert.GET_DEFAULT_DATETIME_FORMAT();
            }
        }

        /// <summary>
        /// retorna a cultura padrão pt-br
        /// </summary>
        /// <returns></returns>
        public static CultureInfo DEFAULT_CULTURE_INFO
        {
            get
            {
                return VtrConvert.GET_DEFAULT_CULTURE_INFO();
            }
        }

        /// <summary>
        /// retorna os NumberStyles padrão para parsear string em inteiro
        /// </summary>
        /// <returns>NumberStyles</returns>
        public static NumberStyles DEFAULT_INTEGER_STYLE
        {
            get
            {
                return VtrConvert.GET_DEFAULT_INTEGER_STYLE();
            }
        }


        /// <summary>
        /// retorna os NumberStyles padrão para parsear string em double
        /// </summary>
        /// <returns>NumberStyles</returns>
        public static NumberStyles DEFAULT_FLOAT_STYLE
        {
            get
            {
                return VtrConvert.GET_DEFAULT_FLOAT_STYLE();
            }
        }

        #endregion

        #region mmétodos estáticos públicos - EXTENSION METHODS DE STRING E OBJECT

        /// <summary>
        /// Se uma string for null ela pode disparar uma exception caso se chame ToUpper ou Trim para normalizá-la. 
        /// Se um objeto for null ele dispara uma exception ao ser convertido para string, e se um objeto for DBNULL ele é diferente de null
        /// Uma chamada a este método resolve a questão e converte qualquer null ou DBNULL para string vazia
        /// </summary>
        /// <param name="obj">objeto a ser analizado</param>
        /// <returns>string</returns>
        public static string TrimNull(this object obj)
        {

            if ((obj == null) || (obj == DBNull.Value) || (obj is DBNull))
            {
                return string.Empty;
            }

            if (obj is string)
            {
                return (obj as string).Trim();
            }

            return obj.ToString();

        }

        /// <summary>
        /// retorna true se um objeto é nulo ou DBNULL
        /// </summary>
        /// <param name="obj">objeto a ser analizado</param>
        /// <returns>null</returns>
        public static bool IsNull(this object obj)
        {
            return ((obj == null) || (obj == DBNull.Value) || (obj is DBNull));
        }

        /// <summary>
        /// converte um objeto para DBNull se ele for null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object ToDBNull(this object obj)
        {
            return obj ?? DBNull.Value;
        }

        #endregion



        #region métodos estáticos públicos - DE OBJETO PARA TIPO PRIMITIVO OU NULÁVEL 


        #region para DateTime

        /// <summary>
        /// converte um objeto para um datetime nulável 
        /// usa parse se o objeto for string, convert caso contrário
        /// </summary>
        /// <param name="obj">objeto a ser convertido para DateTime</param>
        /// <param name="culture">CultureInfo - Cultura para o padrão de formatação</param>
        /// <returns>Datetime?</returns>
        public static DateTime? ToNullableDateTime(object obj, CultureInfo culture)
        {
            if ((obj.IsNull()) || (string.IsNullOrWhiteSpace(obj.ToString())))
                return null;

            if (obj is string)
                return DateTime.Parse(obj.ToString(), culture);

            return Convert.ToDateTime(obj, culture);
        }


        /// <summary>
        /// converte um objeto para um datetime nulável usando a cultura GET_DEFAULT_CULTURE_INFO
        /// </summary>
        /// <param name="obj">objeto a ser convertido</param>
        /// <returns>DateTime?</returns>
        public static DateTime? ToNullableDateTime(object obj)
        {
            return ToNullableDateTime(obj, VtrConvert.GET_DEFAULT_CULTURE_INFO());
        }


        /// <summary>
        /// converte um objeto para um DateTime cusando a cultura dada. 
        /// Converte para o valor mínimo de DateTime se o objeto for nulo
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <param name="culture">CultureInfo - cultura para o padrão de formatação</param>
        /// <returns>DateTime</returns>
        public static DateTime ToDateTime(object obj, CultureInfo culture)
        {
            DateTime result = (ToNullableDateTime(obj, culture) ?? DateTime.MinValue);
            return result;
        }


        /// <summary>
        /// converte um objeto para um DateTime cusando a cultura GET_DEFAULT_CULTURE_INFO. 
        /// Converte para o valor mínimo de DateTime se o objeto for nulo
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <returns>DateTime</returns>
        public static DateTime ToDateTime(object obj)
        {
            return ToDateTime(obj, VtrConvert.GET_DEFAULT_CULTURE_INFO());
        }

        #endregion

        #region para int/Integer/Int32

        /// <summary>
        /// Converte um objeto para um inteiro nulável usando o NumberStyles e o CultureInfo dados
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <param name="style">NumberStyles - conjunto de NumberStyles para saber que tipo de caracteres são suportados/interpretados na conversão</param>
        /// <param name="culture">CultureInfo - cultura para padrão de formatação</param>
        /// <returns>int?</returns>
        public static int? ToNullableInteger(object obj, NumberStyles style, CultureInfo culture)
        {
            if ((obj.IsNull()) || (string.IsNullOrWhiteSpace(obj.ToString())))
                return null;

            if (obj is string)
                return Int32.Parse(obj.ToString(), style, culture);

            return Convert.ToInt32(obj, culture);
        }

        /// <summary>
        /// Converte um objeto para um inteiro nulável usando o CultireInfo dado e usa GET_DEFAULT_INTEGER_STYLE como estilo
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <param name="culture">CultureInfo - cultura para padrão de formatação</param>
        /// <returns>int?</returns>
        public static int? ToNullableInteger(object obj, CultureInfo culture)
        {
            return ToNullableInteger(obj, VtrConvert.GET_DEFAULT_INTEGER_STYLE(), culture);
        }

        /// <summary>
        /// Converte um objeto para um inteiro nulável usando o NumberStyles dado e usando a cultura GET_DEFAULT_CULTURE_INFO
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <param name="style">NumberStyles - conjunto de NumberStyles para saber que tipo de caracteres são suportados/interpretados na conversão</param>
        /// <returns>int?</returns>
        public static int? ToNullableInteger(object obj, NumberStyles style)
        {
            return ToNullableInteger(obj, style, VtrConvert.GET_DEFAULT_CULTURE_INFO());
        }

        /// <summary>
        /// Converte um objeto para um inteiro nulável usando o GET_DEFAULT_INTEGER_STYLE e a GET_DEFAULT_CULTURE_INFO
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <returns>int?</returns>
        public static int? ToNullableInteger(object obj)
        {
            return ToNullableInteger(obj, VtrConvert.GET_DEFAULT_INTEGER_STYLE(), VtrConvert.GET_DEFAULT_CULTURE_INFO());
        }

        /// <summary>
        /// Converte um objeto para inteiro considerando estilo e cultura, se for nulo retorna ZERO
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <param name="style">NumberStyles - conjunto de NumberStyles para saber que tipo de caracteres são suportados/interpretados na conversão</param>
        /// <param name="culture">CultureInfo - cultura para padrão de formatação</param>
        /// <returns>int</returns>
        public static int ToInteger(object obj, NumberStyles style, CultureInfo culture)
        {
            return (ToNullableInteger(obj, style, culture) ?? 0);
        }

        /// <summary>
        /// Converte um objeto para inteiro considerando cultura, se for nulo retorna ZERO
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <param name="culture">CultureInfo - cultura para padrão de formatação</param>
        /// <returns>int</returns>
        public static int ToInteger(object obj, CultureInfo culture)
        {
            return ToInteger(obj, VtrConvert.GET_DEFAULT_INTEGER_STYLE(), culture);
        }

        /// <summary>
        /// Converte um objeto para inteiro considerando estilo, se for nulo retorna ZERO
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <param name="style">NumberStyles - conjunto de NumberStyles para saber que tipo de caracteres são suportados/interpretados na conversão</param>
        /// <returns>int</returns>
        public static int ToInteger(object obj, NumberStyles style)
        {
            return ToInteger(obj, style, VtrConvert.GET_DEFAULT_CULTURE_INFO());
        }


        /// <summary>
        /// Converte um objeto para inteiro considerando as opções padrão, se for nulo retorna ZERO
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <returns>int</returns>
        public static int ToInteger(object obj)
        {
            return ToInteger(obj, VtrConvert.GET_DEFAULT_INTEGER_STYLE(), VtrConvert.GET_DEFAULT_CULTURE_INFO());
        }

        #endregion

        #region para Int64/long

        /// <summary>
        /// Converte um objeto para um Int64 nulável considerando estilo e cultura
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <param name="style">NumberStyles - conjunto de NumberStyles para saber que tipo de caracteres são suportados/interpretados na conversão</param>
        /// <param name="culture">CultureInfo - cultura para padrão de formatação</param>
        /// <returns>Int64?</returns>
        public static Int64? ToNullableInt64(object obj, NumberStyles style, CultureInfo culture)
        {
            if ((obj.IsNull()) || (string.IsNullOrWhiteSpace(obj.ToString())))
                return null;

            if (obj is string)
                return Int64.Parse(obj.ToString(), style, culture);

            return Convert.ToInt64(obj, culture);
        }


        /// <summary>
        /// Converte um objeto para um Int64 nulável considerando cultura
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <param name="culture">CultureInfo - cultura para padrão de formatação</param>
        /// <returns>Int64?</returns>
        public static Int64? ToNullableInt64(object obj, CultureInfo culture)
        {
            return ToNullableInt64(obj, VtrConvert.GET_DEFAULT_INTEGER_STYLE(), culture);
        }

        /// <summary>
        /// Converte um objeto para um Int64 nulável considerando estilo
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <param name="style">NumberStyles - conjunto de NumberStyles para saber que tipo de caracteres são suportados/interpretados na conversão</param>
        /// <returns>Int64?</returns>
        public static Int64? ToNullableInt64(object obj, NumberStyles style)
        {
            return ToNullableInt64(obj, style, VtrConvert.GET_DEFAULT_CULTURE_INFO());
        }

        /// <summary>
        /// Converte um objeto para um Int64 nulável considerando estilo e cultura padrão
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <returns>Int64?</returns>
        public static Int64? ToNullableInt64(object obj)
        {
            return ToNullableInt64(obj, VtrConvert.GET_DEFAULT_INTEGER_STYLE(), VtrConvert.GET_DEFAULT_CULTURE_INFO());
        }

        /// <summary>
        /// Converte um objeto para um Int64 considerando estilo e cultura, se for nulo retorna zero
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <param name="style">NumberStyles - conjunto de NumberStyles para saber que tipo de caracteres são suportados/interpretados na conversão</param>
        /// <param name="culture">CultureInfo - cultura para padrão de formatação</param>
        /// <returns>Int64</returns>
        public static Int64 ToInt64(object obj, NumberStyles style, CultureInfo culture)
        {
            return (ToNullableInt64(obj, style, culture) ?? 0);
        }

        /// <summary>
        /// Converte um objeto para um Int64 considerando cultura, se for nulo retorna zero
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <param name="culture">CultureInfo - cultura para padrão de formatação</param>
        /// <returns>Int64</returns>
        public static Int64 ToInt64(object obj, CultureInfo culture)
        {
            return ToInt64(obj, VtrConvert.GET_DEFAULT_INTEGER_STYLE(), culture);
        }

        /// <summary>
        /// Converte um objeto para um Int64 considerando estilo, se for nulo retorna zero
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <param name="style">NumberStyles - conjunto de NumberStyles para saber que tipo de caracteres são suportados/interpretados na conversão</param>
        /// <returns>Int64</returns>
        public static Int64 ToInt64(object obj, NumberStyles style)
        {
            return ToInt64(obj, style, VtrConvert.GET_DEFAULT_CULTURE_INFO());
        }

        /// <summary>
        /// Converte um objeto para um Int64 considerando estilo e cultura padrão, se for nulo retorna zero
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <returns>Int64</returns>
        public static Int64 ToInt64(object obj)
        {
            return ToInt64(obj, VtrConvert.GET_DEFAULT_INTEGER_STYLE(), VtrConvert.GET_DEFAULT_CULTURE_INFO());
        }

        #endregion

        #region para double

        /// <summary>
        /// Converte um objeto para um double nulável de acordo com o estilo e cultura 
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <param name="style">NumberStyles - conjunto de NumberStyles para saber que tipo de caracteres são suportados/interpretados na conversão</param>
        /// <param name="culture">CultureInfo - cultura para padrão de formatação</param>
        /// <returns>double?</returns>
        public static double? ToNullableDouble(object obj, NumberStyles style, CultureInfo culture)
        {
            if ((obj.IsNull()) || (string.IsNullOrWhiteSpace(obj.ToString())))
                return null;

            if (obj is string)
                return double.Parse(obj.ToString(), style, culture);

            return Convert.ToDouble(obj, culture);

        }

        /// <summary>
        /// Converte um objeto para um double nulável de acordo com a cultura 
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <param name="culture">CultureInfo - cultura para padrão de formatação</param>
        /// <returns>double?</returns>
        public static double? ToNullableDouble(object obj, CultureInfo culture)
        {
            return ToNullableDouble(obj, VtrConvert.GET_DEFAULT_FLOAT_STYLE(), culture);
        }

        /// <summary>
        /// Converte um objeto para um double nulável de acordo com o estilo 
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <param name="style">NumberStyles - conjunto de NumberStyles para saber que tipo de caracteres são suportados/interpretados na conversão</param>
        /// <returns>double?</returns>
        public static double? ToNullableDouble(object obj, NumberStyles style)
        {
            return ToNullableDouble(obj, style, VtrConvert.GET_DEFAULT_CULTURE_INFO());
        }

        /// <summary>
        /// Converte um objeto para um double nulável de acordo com o estilo e cultura padrões
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <returns>double?</returns>
        public static double? ToNullableDouble(object obj)
        {
            return ToNullableDouble(obj, VtrConvert.GET_DEFAULT_FLOAT_STYLE(), VtrConvert.GET_DEFAULT_CULTURE_INFO());
        }


        /// <summary>
        /// Converte um objeto para um double de acordo com o estilo e cultura, se for nulo retorna zero
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <param name="style">NumberStyles - conjunto de NumberStyles para saber que tipo de caracteres são suportados/interpretados na conversão</param>
        /// <param name="culture">CultureInfo - cultura para padrão de formatação</param>
        /// <returns>double</returns>
        public static double ToDouble(object obj, NumberStyles style, CultureInfo culture)
        {
            return (ToNullableDouble(obj, style, culture) ?? 0);
        }

        /// <summary>
        /// Converte um objeto para um double  de acordo com a cultura, se for nulo retorna zero
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <param name="culture">CultureInfo - cultura para padrão de formatação</param>
        /// <returns>double</returns>
        public static double ToDouble(object obj, CultureInfo culture)
        {
            return ToDouble(obj, VtrConvert.GET_DEFAULT_FLOAT_STYLE(), culture);
        }

        /// <summary>
        /// Converte um objeto para um double  de acordo com o estilo, se for nulo retorna zero
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <param name="style">NumberStyles - conjunto de NumberStyles para saber que tipo de caracteres são suportados/interpretados na conversão</param>
        /// <returns>double</returns>
        public static double ToDouble(object obj, NumberStyles style)
        {
            return ToDouble(obj, style, VtrConvert.GET_DEFAULT_CULTURE_INFO());
        }


        /// <summary>
        /// Converte um objeto para um double  de acordo com o estilo e cultura padrões, se for nulo retorna zero
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <returns>double</returns>
        public static double ToDouble(object obj)
        {
            return ToDouble(obj, VtrConvert.GET_DEFAULT_FLOAT_STYLE(), VtrConvert.GET_DEFAULT_CULTURE_INFO());
        }

        #endregion

        #region para bool

        /// <summary>
        /// converte um objeto para um bool nulável segundo a cultura
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <param name="culture">CultureInfo - cultura para padrão de formatação</param>
        /// <returns>bool?</returns>
        public static bool? ToNullableBool(object obj, CultureInfo culture)
        {
            if ((obj.IsNull()) || (string.IsNullOrWhiteSpace(obj.ToString())))
                return null;

            if (obj is string)
                return bool.Parse(obj.ToString());

            return Convert.ToBoolean(obj, culture);
        }

        /// <summary>
        /// converte um objeto para um bool nulável segundo a cultura padrão
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <returns>bool?</returns>
        public static bool? ToNullableBool(object obj)
        {
            return ToNullableBool(obj, VtrConvert.GET_DEFAULT_CULTURE_INFO());
        }

        /// <summary>
        /// converte um objeto para um bool segundo a cultura, se for null retorna false
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <param name="culture">CultureInfo - cultura para padrão de formatação</param>
        /// <returns>bool</returns>
        public static bool ToBool(object obj, CultureInfo culture)
        {
            return (ToNullableBool(obj, culture) ?? false);
        }

        /// <summary>
        /// converte um objeto para um bool segundo a cultura padrão, se for null retorna false
        /// </summary>
        /// <param name="obj">Objeto a ser convertido</param>
        /// <returns>bool</returns>
        public static bool ToBool(object obj)
        {
            return ToBool(obj, VtrConvert.GET_DEFAULT_CULTURE_INFO());
        }

        #endregion


        #region para Enum

        /// <summary>
        /// converte um objeto para um Enum definido wem T que pode ser nulável
        /// </summary>
        /// <typeparam name="T">O tipo do enum</typeparam>
        /// <param name="obj">o objeto a ser convertido</param>
        /// <returns>Um enum do tipo T</returns>
        public static T? ToNullableEnum<T>(object obj) where T : struct, IConvertible
        {
            try
            {

                if (!typeof(T).IsEnum)
                {
                    throw new ArgumentException("T precisa ser um tipo Enum");
                }

                if (obj.IsNull())
                    return null;

                if (obj is T)
                    return (T)obj;

                if (obj is Enum)
                    return (T)obj;

                if (obj is string)
                {
                    string stmp = (obj as string);
                    int itmp = 0;
                    T ttmp;
                    if (Int32.TryParse(stmp, out itmp))
                    {
                        return (T)Enum.ToObject(typeof(T), itmp);
                    }
                    else if (Enum.TryParse<T>(stmp, out ttmp))
                    {
                        return ttmp;
                    }
                    else
                    {
                        return null;
                    }
                }

                if (obj is int)
                    return (T)Enum.ToObject(typeof(T), (int)obj);

                if (obj is uint)
                    return (T)Enum.ToObject(typeof(T), (uint)obj);

                if (obj is long)
                    return (T)Enum.ToObject(typeof(T), (long)obj);

                if (obj is ulong)
                    return (T)Enum.ToObject(typeof(T), (ulong)obj);

                if (obj is byte)
                    return (T)Enum.ToObject(typeof(T), (byte)obj);

                if (obj is sbyte)
                    return (T)Enum.ToObject(typeof(T), (sbyte)obj);


                return (T)obj;
            }
            catch
            {
                return null;
            }
        }




        /// <summary>
        /// converte um objeto para um Enum definido wem T que se for nulo trará o elemento 0 deste
        /// </summary>
        /// <typeparam name="T">O tipo do enum</typeparam>
        /// <param name="obj">o objeto a ser convertido</param>
        /// <returns>Um enum do tipo T</returns>
        public static T ToEnum<T>(object obj) where T : struct, IConvertible
        {
            try
            {
                if (!typeof(T).IsEnum)
                {
                    throw new ArgumentException("T precisa ser um tipo Enum");
                }

                if (obj.IsNull())
                    //return (T)Enum.ToObject(typeof(T), 0); 
                    return default(T);

                if (obj is T)
                    return (T)obj;

                if (obj is Enum)
                    return (T)obj;

                if (obj is string)
                {
                    string stmp = (obj as string);
                    int itmp = 0;
                    T ttmp;
                    if (Int32.TryParse(stmp, out itmp))
                    {
                        return (T)Enum.ToObject(typeof(T), itmp);
                    }
                    else if (Enum.TryParse<T>(stmp, out ttmp))
                    {
                        return ttmp;
                    }
                    else
                    {
                        //return (T)Enum.ToObject(typeof(T), 0); 
                        return default(T);
                    }
                }

                if (obj is int)
                    return (T)Enum.ToObject(typeof(T), (int)obj);

                if (obj is uint)
                    return (T)Enum.ToObject(typeof(T), (uint)obj);

                if (obj is long)
                    return (T)Enum.ToObject(typeof(T), (long)obj);

                if (obj is ulong)
                    return (T)Enum.ToObject(typeof(T), (ulong)obj);

                if (obj is byte)
                    return (T)Enum.ToObject(typeof(T), (byte)obj);

                if (obj is sbyte)
                    return (T)Enum.ToObject(typeof(T), (sbyte)obj);


                return (T)obj;
            }
            catch
            {
                //return (T)Enum.ToObject(typeof(T), 0); 
                return default(T);
            }
        }

        #endregion



        #endregion

        #region métodos estáticos públicos - CONVERSAO DE TIPO NULÁVEL PARA STRING 

        #region DateTime

        /// <summary>
        /// transforma um DateTime? nulável em string, "" se for null
        /// </summary>
        /// <param name="Data">Data a ser convertida</param>
        /// <param name="format">formato da data</param>
        /// <param name="culture">cultura da data</param>
        /// <returns>string</returns>
        public static string ToString(DateTime? data, string format, IFormatProvider culture)
        {
            if ((data == null) || (!data.HasValue) || (data.Value == DateTime.MinValue))
                return "";

            return data.Value.ToString(format, culture);
        }

        /// <summary>
        /// transforma um DateTime? nulável em string, "" se for null, usando a CultureInfo padrão
        /// </summary>
        /// <param name="Data">data a ser convertida</param>
        /// <param name="format">formata da conversão</param>
        /// <returns>string</returns>
        public static string ToString(DateTime? data, string format)
        {
            return ToString(data, format, GET_DEFAULT_CULTURE_INFO());
        }

        /// <summary>
        /// transforma um DateTime? nulável em string, "" se for null, usando a CultureInfo padrão e formato padrão
        /// </summary>
        /// <param name="Data">data a ser convertida</param>
        /// <returns>string</returns>
        public static string ToString(DateTime? data)
        {
            return ToString(data, GET_DEFAULT_DATETIME_FORMAT());
        }

        #endregion


        #region Int32/Int64

        /// <summary>
        /// transforma um int? nulável em string, "" se for null, considerando a cultura e o formato
        /// </summary>
        /// <param name="numero">int? - número a ser convertido</param>
        /// <param name="format">formato do número</param>
        /// <param name="culture">cultura para a conversão</param>
        /// <returns>string</returns>
        public static string ToString(int? numero, string format, IFormatProvider culture)
        {
            if ((numero == null) || (!numero.HasValue))
                return "";

            return numero.Value.ToString(format, culture);
        }

        /// <summary>
        /// transforma um int? nulável em string, "" se for null, usando o CultureInfo Padrao
        /// </summary>
        /// <param name="numero">int? - número a ser convertido</param>
        /// <param name="format">formato do número</param>
        /// <returns>string</returns>
        public static string ToString(int? numero, string format)
        {
            return ToString(numero, format, GET_DEFAULT_CULTURE_INFO());
        }

        /// <summary>
        /// transforma um int? nulável em string, "" se for null, usando o CultureInfo Padrao e o formato padrão
        /// </summary>
        /// <param name="numero">int? - número a ser convertido</param>
        /// <returns>string</returns>
        public static string ToString(int? numero)
        {
            return ToString(numero, GET_DEFAULT_INTEGER_FORMAT());
        }

        /// <summary>
        /// transforma um long? nulável em string, "" se for null, considerando o formato e a cultura
        /// </summary>
        /// <param name="numero">numero a ser convertido</param>
        /// <param name="format">formato</param>
        /// <param name="culture">cultura</param>
        /// <returns>string</returns>
        public static string ToString(Int64? numero, string format, IFormatProvider culture)
        {
            if ((numero == null) || (!numero.HasValue))
                return "";

            return numero.Value.ToString(format, culture);
        }

        /// <summary>
        /// transforma um long? nulável em string, "" se for null, usando CultureInfo padrão
        /// </summary>
        /// <param name="numero">numero a ser convertido</param>
        /// <param name="format">formato</param>
        /// <returns>string</returns>
        public static string ToString(Int64? numero, string format)
        {
            return ToString(numero, format, GET_DEFAULT_CULTURE_INFO());
        }

        /// <summary>
        /// transforma um long? nulável em string, "" se for null, usando CultureInfo padrão e formato padrão
        /// </summary>
        /// <param name="numero">numero a ser convertido</param>
        /// <returns>string</returns>
        public static string ToString(Int64? numero)
        {
            return ToString(numero, GET_DEFAULT_INTEGER_FORMAT());
        }

        #endregion


        #region double/float

        /// <summary>
        /// transforma um double? nulável em string, "" se for null, considerando formato e cultura
        /// </summary>
        /// <param name="numero">numero a ser convertido</param>
        /// <param name="format">formato</param>
        /// <param name="culture">cultura</param>
        /// <returns>string</returns>
        public static string ToString(double? numero, string format, IFormatProvider culture)
        {
            if ((numero == null) || (!numero.HasValue))
                return "";

            return numero.Value.ToString(format, culture);
        }


        /// <summary>
        /// transforma um double? nulável em string, "" se for null, usando CultureInfo padrão
        /// </summary>
        /// <param name="numero">numero a ser convertido</param>
        /// <param name="format">formato</param>
        /// <returns>string</returns>
        public static string ToString(double? numero, string format)
        {
            return ToString(numero, format, GET_DEFAULT_CULTURE_INFO());
        }

        /// <summary>
        /// transforma um double? nulável em string, "" se for null, usando CultureInfo padrão e formato padrão
        /// </summary>
        /// <param name="numero">numero a ser convertido</param>
        /// <returns>string</returns>
        public static string ToString(double? numero)
        {
            return ToString(numero, GET_DEFAULT_FLOAT_FORMAT());
        }

        #endregion


        #region bool

        /// <summary>
        /// transforma um bool? nulável em string, "" se for null
        /// </summary>
        /// <param name="numero">bool a ser convertido</param>
        /// <param name="culture">cultura</param>         
        /// <returns>string</returns>
        public static string ToString(bool? flag, CultureInfo culture)
        {
            string resultado = string.Empty;
            resultado = (flag != null && flag.HasValue) ? flag.Value.ToString(culture) : "";
            return resultado;
        }


        /// <summary>
        /// transforma um bool? nulável em string, "" se for null
        /// </summary>
        /// <param name="numero">bool a ser convertido</param>
        /// <returns>string</returns>
        public static string ToString(bool? flag)
        {
            return ToString(flag, VtrConvert.GET_DEFAULT_CULTURE_INFO());
        }

        /// <summary>
        /// converte um bool? nulável para string conforme preferências do desenvolvedor
        /// </summary>
        /// <param name="flag">bool - a flag a ser convertida</param>
        /// <param name="valorSeNull">string - valor retornado se a flag for null</param>
        /// <param name="valorSeTrue">string - valor retornado se a flag for true</param>
        /// <param name="valorSeFalse">string - valor retornado se a flag for false</param>
        /// <returns>string</returns>
        public static string ToString(bool? flag, string valorSeNull, string valorSeTrue, string valorSeFalse)
        {
            string resultado = string.Empty;
            resultado = (flag != null && flag.HasValue) ? (flag.Value ? valorSeTrue : valorSeFalse) : valorSeNull;
            return resultado;
        }

        #endregion


        #region Enum

        /// <summary>
        /// Traz o texto de um Enum, se houver
        /// O texto trazido não é conversível de volta para Enum
        /// </summary>
        /// <param name="valor">Enum - valor a ser convertido para string</param>
        /// <returns></returns>
        public static string ToString(Enum valor)
        {
            if (valor == null)
                return "";

            return valor.ToText();
        }

        #endregion

        #endregion



        #region métodos estáticos PRIVADOS - FORMATOS PADRÃO

        /// <summary>
        /// retorna o formato padrão de inteiros
        /// </summary>
        /// <returns></returns>
        private static string GET_DEFAULT_INTEGER_FORMAT()
        {
            return "###,##0";
        }

        /// <summary>
        /// retorna o formato padrão de decimais
        /// </summary>
        /// <returns></returns>
        private static string GET_DEFAULT_FLOAT_FORMAT()
        {
            return "###,##0.00";
        }

        /// <summary>
        /// retorna o formato padrão de datas
        /// </summary>
        /// <returns></returns>
        private static string GET_DEFAULT_DATE_FORMAT()
        {
            return "dd/MM/yyyy";
        }

        /// <summary>
        /// retorna o formato padrão de data/hora
        /// </summary>
        /// <returns></returns>
        private static string GET_DEFAULT_DATETIME_FORMAT()
        {
            return "dd/MM/yyyy HH:mm:ss";
        }

        /// <summary>
        /// retorna a cultura padrão pt-br
        /// </summary>
        /// <returns></returns>
        private static CultureInfo GET_DEFAULT_CULTURE_INFO()
        {
            return new CultureInfo("pt-BR");
        }

        /// <summary>
        /// retorna os NumberStyles padrão para parsear string em inteiro
        /// </summary>
        /// <returns>NumberStyles</returns>
        private static NumberStyles GET_DEFAULT_INTEGER_STYLE()
        {
            return NumberStyles.AllowThousands |
                NumberStyles.AllowCurrencySymbol |
                NumberStyles.AllowLeadingWhite |
                NumberStyles.AllowTrailingWhite |
                NumberStyles.AllowTrailingSign |
                NumberStyles.AllowLeadingSign;
        }


        /// <summary>
        /// retorna os NumberStyles padrão para parsear string em double
        /// </summary>
        /// <returns>NumberStyles</returns>
        private static NumberStyles GET_DEFAULT_FLOAT_STYLE()
        {
            return NumberStyles.AllowThousands |
                NumberStyles.AllowDecimalPoint |
                NumberStyles.AllowCurrencySymbol |
                NumberStyles.AllowLeadingWhite |
                NumberStyles.AllowTrailingWhite |
                NumberStyles.AllowTrailingSign |
                NumberStyles.AllowLeadingSign;
        }

        #endregion

    }
}
