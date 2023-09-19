import AuthApiClient from "./AuthApiClient";
export interface Category {
  id: number;
  title: string;
  parentCategoryId: number | null; // Use null for top-level categories
  index: number;
}
class CategoryService {
  getAll(setCategories: any) {
    AuthApiClient()
      .get("category/get-all")
      .then((res: any) => setCategories(res.data))
      .catch((err: any) => console.log(err));
  }

  getById(id: any, setCategory: any) {
    AuthApiClient()
      .get(`category/get-by-id?id=${id}`)
      .then((res: any) => setCategory(res.data))
      .catch((err: any) => console.log(err));
  }

  getSubCategoriesByParentId(parentId: any, setSubCategories: any) {
    AuthApiClient()
      .get(`category/get-sub-categories-by-parent-id?id=${parentId}`)
      .then((res: any) => setSubCategories(res.data))
      .catch((err: any) => console.log(err));
  }

  getAllSubCategories(parentId: any, setSubCategories: any) {
    AuthApiClient()
      .get(`category/get-all-sub-categories-by-parent-id?id=${parentId}`)
      .then((res: any) => setSubCategories(res.data))
      .catch((err: any) => console.log(err));
  }

  createRoot(title: any, onSuccess: any, onError: any) {
    AuthApiClient()
      .post("category/create-root", { title })
      .then((res: any) => onSuccess(res.data))
      .catch((err: any) => onError(err));
  }

  createWithParent(title: any, parentId: any, onSuccess: any, onError: any) {
    AuthApiClient()
      .post("category/create-with-parent", { title, parentId })
      .then((res: any) => onSuccess(res.data))
      .catch((err: any) => onError(err));
  }

  update(id: any, title: any, onSuccess: any, onError: any) {
    AuthApiClient()
      .patch("category/update", { id, title })
      .then((res: any) => onSuccess(res.data))
      .catch((err: any) => onError(err));
  }

  updateParentId(id: any, parentId: any, onSuccess: any, onError: any) {
    AuthApiClient()
      .patch("category/update-parent-id", { id, parentId })
      .then((res: any) => onSuccess(res.data))
      .catch((err: any) => onError(err));
  }

  deleteCategory(id: any, onSuccess: any, onError: any) {
    AuthApiClient()
      .delete(`category/delete`, { data: { id } })
      .then((res: any) => onSuccess(res.data))
      .catch((err: any) => onError(err));
  }
}

export default CategoryService;
