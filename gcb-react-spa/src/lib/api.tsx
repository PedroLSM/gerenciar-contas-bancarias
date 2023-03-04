import axios from "axios";

import { Referencia } from "../models/Referencia";

const instance = axios.create({
  baseURL: `${process.env.REACT_APP_API_END_POINT}/GCB`,
});

export const obterHistoricoExtrato = async (extratoId: string) => {
  const response = await instance.get("/Extrato/Historico", {
    params: { extratoId: `${extratoId}` },
  });

  const responseData = response.data;

  return responseData;
};

export const obterContasTransferencia = async (params: any) => {
  const { referenciaId, extratoId } = params;
  const response = await instance.get("/Extrato/ContasTransferencia", {
    params: {
      referenciaId: `${referenciaId}`,
      extratoId: `${extratoId}`,
    },
  });

  const responseData = response.data;

  return responseData;
};

export const obterExtrato = async (referenciaId: string) => {
  const response = await instance.get("/Extrato", {
    params: { referenciaId: `${referenciaId}` },
  });

  const responseData = response.data;

  return responseData;
};

export const retiradaBancaria = async (deposito: any) => {
  const response = await instance.post(
    "/Extrato/Adicionar/RetiradaBancaria",
    deposito
  );

  const responseData = response.data;

  return responseData;
};

export const carregarExtrato = async (extrato: any) => {
  var bodyFormData = new FormData();

  console.log(extrato);

  bodyFormData.append("ExtratoId", extrato.extratoId);
  bodyFormData.append("Arquivo", extrato.arquivo);

  const response = await instance.post(
    "/Extrato/Adicionar/Extrato",
    bodyFormData,
    { headers: { "Content-Type": "multipart/form-data" } }
  );

  const responseData = response.data;

  return responseData;
};

export const depositoBancario = async (deposito: any) => {
  const response = await instance.post(
    "/Extrato/Adicionar/DepositoBancario",
    deposito
  );

  const responseData = response.data;

  return responseData;
};

export const adicionarContaBancaria = async (contaBancaria: any) => {
  const response = await instance.post(
    "/ContaBancaria/Adicionar",
    contaBancaria
  );

  const responseData = response.data;

  return responseData;
};

export const obterReferencias = async () => {
  const response = await instance.get("/Referencia");

  const referenciasMapped = mapReferencias(response.data);

  return referenciasMapped;
};

const mapReferencias = (referencias: Referencia[]) => {
  if (!referencias) {
    return { anoReferencia: 0, meses: [] };
  }

  const todos: any = referencias.map((s) => s.meses);

  referencias.unshift({
    anoReferencia: 0,
    meses: [].concat.apply([], todos),
  });

  return referencias;
};
