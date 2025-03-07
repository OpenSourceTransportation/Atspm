// #region license
// Copyright 2024 Utah Departement of Transportation
// for WebUI - usePatchRequest.ts
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//http://www.apache.org/licenses/LICENSE-2.
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// #endregion
import { configAxios } from '@/lib/axios'
import { queryClient } from '@/lib/react-query'
import { useNotificationStore } from '@/stores/notifications'
import { AxiosHeaders, AxiosInstance, AxiosResponse } from 'axios'
import { useMutation } from 'react-query'

interface patchRequestDto<D> {
  url: string
  data: D
  axiosInstance: AxiosInstance
  headers: AxiosHeaders
}

export async function patchRequest<T, D>({
  url,
  data,
  axiosInstance,
  headers,
}: patchRequestDto<D>): Promise<AxiosResponse<T>> {
  return axiosInstance.patch<T>(url, data, { headers })
}

type UseDataOptions = {
  url: string
  headers: AxiosHeaders
  axiosInstance?: AxiosInstance
  notify?: boolean
}

interface MutationParams<D> {
  data: D
  id: number | string
}

export function usePatchRequest<T, D>({
  url,
  headers,
  axiosInstance = configAxios,
  notify = true,
}: UseDataOptions) {
  const { addNotification } = useNotificationStore()
  return useMutation<AxiosResponse<T>, unknown, MutationParams<D>, unknown>({
    onMutate: async (obj: MutationParams<D>) => {
      await queryClient.cancelQueries([url])

      const previousObjs = queryClient.getQueryData<any[]>([url])

      queryClient.setQueryData([url], [...(previousObjs || []), obj.data])

      return { previousObjs }
    },
    onError: (_, __, context: any) => {
      if (notify) {
        addNotification({
          type: 'error',
          title: `${url.replace('/', '')} Request failed`,
        })
      }
      if (context?.previousObjs) {
        queryClient.setQueryData([url], context.previousObjs)
      }
    },
    onSuccess: () => {
      queryClient.invalidateQueries([url])
      if (notify) {
        addNotification({
          type: 'info',
          title: `${url.replace('/', '')} Updated`,
        })
      }
    },
    mutationFn: async (obj: MutationParams<D>) =>
      patchRequest<T, D>({
        url: `${url}/${obj.id}`,
        data: obj.data,
        axiosInstance,
        headers,
      }),
  })
}
