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

  createRoot(title: any, navigate: any, onError: any) {
    AuthApiClient()
      .post("category/create-root", { title })
      .then((res) => navigate("/admin/category"))
      .catch((err) => onError(err));
  }

  createWithParent(title: any, parentId: any, navigate: any, onError: any) {
    AuthApiClient()
      .post("category/create-with-parent", { title, parentId })
      .then((res: any) => navigate("/admin/category"))
      .catch((err: any) => onError(err));
  }

  update(id: any, title: any, navigate: any, onError: any) {
    return AuthApiClient().patch("category/update", { id, title });
  }

  updateParentId(id: any, parentId: any, navigate: any, onError: any) {
    AuthApiClient()
      .patch("category/update-parent-id", { id, parentId })
      .then((res) => navigate("/admin/category"))
      .catch((err: any) => onError(err));
  }

  removeParentId(id: any, navigate: any, onError: any) {
    AuthApiClient()
      .patch("category/remove-parent-id", { id })
      .then((res) => navigate("/admin/category"))
      .catch((err) => onError(err));
  }

  deleteCategory(id: any, navigate: any, onError: any) {
    AuthApiClient()
      .delete(`category/delete`, { data: { id } })
      .then((res: any) => navigate("/admin/category"))
      .catch((err: any) => onError(err));
  }
}

export default CategoryService;
