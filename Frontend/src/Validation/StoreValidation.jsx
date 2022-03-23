import * as yup from "yup";

export const storeSchema = yup.object().shape({
	name: yup.string().required(),
	adress: yup.string().required(),
	city: yup.string().required(),
	zip: yup.number().required(),
	country: yup.string().required(),
	longitude: yup.number(),
	latitude: yup.number(),
});

export const companySchema = yup.object().shape({
	name: yup.string().required(),
	organizationnumberId: yup.number().required(),
	note: "",
});

export const LngLatSchema = yup.object().shape({
	longitude: yup.number().required(),
	latitude: yup.number().required(),
});
