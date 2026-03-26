import api from './api';

export const partnerService = {
  updateStatus: async (activity, focus) => {
    try {
      const response = await api.put('/partners/update-status', {
        activity,
        focus: parseInt(focus)
      });
      return response.data;
    } catch (error) {
      throw error.response?.data?.message || "Erro ao atualizar status";
    }
  }
};