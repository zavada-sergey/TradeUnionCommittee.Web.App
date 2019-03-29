﻿using HashidsNet;
using System;
using TradeUnionCommittee.BLL.Exceptions;

namespace TradeUnionCommittee.BLL.Configurations
{
    public class HashIdConfigurationSetting
    {
        public string Salt { get; set; }
        public int MinHashLenght { get; set; }
        public string Alphabet { get; set; }
        public string Seps { get; set; }
        public bool UseGuidFormat { get; set; }
    }

    public interface IHashIdConfiguration
    {
        long DecryptLong(string cipherText);
        string EncryptLong(long plainLong);
    }

    internal sealed class HashIdConfiguration : IHashIdConfiguration
    {
        private readonly bool _useGuidFormat;
        private readonly Hashids _hashId;

        public HashIdConfiguration(HashIdConfigurationSetting setting)
        {
            if (setting.UseGuidFormat)
            {
                setting.MinHashLenght = 32;
                setting.Alphabet = setting.Alphabet.Replace("-", string.Empty).ToLower();
            }
            _useGuidFormat = setting.UseGuidFormat;
            _hashId = new Hashids(setting.Salt, setting.MinHashLenght, setting.Alphabet, setting.Seps);
        }

        public long DecryptLong(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText) || string.IsNullOrWhiteSpace(cipherText))
            {
                throw new DecryptHashIdException();
            }

            long[] result;

            if (_useGuidFormat)
            {
                result = _hashId.DecodeLong(GuidFormat(cipherText, HashIdOperation.Decrypt));
            }
            else
            {
                result = _hashId.DecodeLong(cipherText);
            }

            if (result.Length == 1)
            {
                return result[0];
            }
            throw new DecryptHashIdException();
        }

        public string EncryptLong(long plainLong)
        {
            if (_useGuidFormat)
            {
                return GuidFormat(_hashId.EncodeLong(plainLong), HashIdOperation.Encrypt);
            }
            return _hashId.EncodeLong(plainLong);
        }

        private string GuidFormat(string hash, HashIdOperation hashId)
        {
            switch (hashId)
            {
                case HashIdOperation.Encrypt:
                    return hash.Insert(8, "-").Insert(13, "-").Insert(18, "-").Insert(23, "-");
                case HashIdOperation.Decrypt:
                    return hash.Replace("-", string.Empty);
                default:
                    throw new ArgumentOutOfRangeException(nameof(hashId), hashId, null);
            }
        }

        private enum HashIdOperation
        {
            Encrypt,
            Decrypt
        }
    }
}